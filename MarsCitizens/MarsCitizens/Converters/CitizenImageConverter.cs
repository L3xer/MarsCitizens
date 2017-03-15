using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using PCLStorage;
using Xamarin.Forms;

namespace MarsCitizens.Converters
{
    class CitizenImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var uri = new Uri(value.ToString());
            string imageName = Path.GetFileName(uri.LocalPath);
            string imagePath = GetImagePath(uri, imageName);

            return ImageSource.FromFile(imagePath);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private bool IsImageExists(string imageName)
        {
            return Task.Run(() => FileSystem.Current.LocalStorage.CheckExistsAsync(imageName)).Result == ExistenceCheckResult.FileExists;
        }

        private string GetImagePath(Uri uri, string imageName)
        {
            IFile imageFile;

            var rootFolder = FileSystem.Current.LocalStorage;
            if (IsImageExists(imageName)) {
                imageFile = Task.Run(() => rootFolder.GetFileAsync(imageName)).Result;
            } else {
                imageFile = Task.Run(() => rootFolder.CreateFileAsync(imageName, CreationCollisionOption.ReplaceExisting)).Result;
                Task.Run(() => DownloadImage(uri, imageFile)).Wait();                
            }

            return imageFile.Path;
        }

        private static async Task DownloadImage(Uri uri, IFile file)
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
