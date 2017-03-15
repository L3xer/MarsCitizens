using System.IO;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using MarsCitizens.Contracts.Services;
using MarsCitizens.Extensions;
using MarsCitizens.Models;
using PCLStorage;


namespace MarsCitizens.Services
{
    public class CitizenService : ICitizenService
    {
        private readonly string url = "https://dl.dropboxusercontent.com/s/vt4ra077675fve7/citiziens.json";

        private IDataService _dataService;

        public CitizenService(IDataService dataService)
        {
            if (dataService == null)
                throw new ArgumentException(nameof(dataService));

            _dataService = dataService;
        }

        public async Task<Result<IEnumerable<Citizen>>> GetAllAsync()
        {
            var result = await GetCitizensAsync();
            if (result.IsFailure)
                return Result.Fail<IEnumerable<Citizen>>(result.Error);

            foreach(var citizen in result.Value) {
                await DownloadImageIfNotExistsAsync(citizen.Thumbnail);
            }


            return Result.Ok(result.Value);
        }

        private async Task<Result<IEnumerable<Citizen>>> GetCitizensAsync()
        {
            IEnumerable<Citizen> citizens = (await _dataService.GetAsync<List<Citizen>>(url))?.OrderByDescending(x => x.LandingDate).ToArray();

            if (citizens == null || citizens.Count() <= 0)
                return Result.Fail<IEnumerable<Citizen>>("Network problems. Please try again later.");

            return Result.Ok(citizens);
        }

        private async Task DownloadImageIfNotExistsAsync(string url)
        {
            var uri = new Uri(url);
            string imageName = Path.GetFileName(uri.LocalPath);

            var rootFolder = FileSystem.Current.LocalStorage;
            if (!await IsImageExistsAsync(imageName)) {
                var imageFile = await rootFolder.CreateFileAsync(imageName, CreationCollisionOption.ReplaceExisting);
                await DownloadImageAsync(uri, imageFile);
            }
        }

        private async Task<bool> IsImageExistsAsync(string imageName)
        {
            return await FileSystem.Current.LocalStorage.CheckExistsAsync(imageName) == ExistenceCheckResult.FileExists;
        }

        private static async Task DownloadImageAsync(Uri uri, IFile file)
        {
            using (var client = new HttpClient())
            using (var fileHandler = await file.OpenAsync(FileAccess.ReadAndWrite)) {
                var httpResponse = await client.GetAsync(uri);
                byte[] dataBuffer = await httpResponse.Content.ReadAsByteArrayAsync();
                await fileHandler.WriteAsync(dataBuffer, 0, dataBuffer.Length);
            }
        }



    }
}
