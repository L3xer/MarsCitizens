using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarsCitizens.Dtos;
using MarsCitizens.Models;
using MarsCitizens.Extensions;
using MarsCitizens.Contracts.Services;
using MarsCitizens.Contracts.Repository;


namespace MarsCitizens.Repositories
{
    public class PhotoCameraRepository : IPhotoCameraRepository
    {
        private readonly string manifestUrl = "https://api.nasa.gov/mars-photos/api/v1/manifests/{ROVERNAME}?api_key=WumLUIspPJo8xHnjTPkCgvi03lolmgUnbraJvPgl";
        private readonly string photosUrl = "https://api.nasa.gov/mars-photos/api/v1/rovers/{ROVERNAME}/photos?sol={SOL}&api_key=WumLUIspPJo8xHnjTPkCgvi03lolmgUnbraJvPgl";

        private IDataService _dataService;


        public PhotoCameraRepository(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<Result<int>> GetMaxSolAsync(string roverName)
        {
            var roverManifestDto = await _dataService.GetAsync<RoverManifestDto>(manifestUrl.Replace("{ROVERNAME}", roverName));

            if (roverManifestDto == null || roverManifestDto.Manifest == null)
                return Result.Fail<int>("Network problems. Please try again later.");

            return Result.Ok(roverManifestDto.Manifest.MaxSol);
        }

        public async Task<Result<IEnumerable<Photo>>> GetPhotosAsync(string roverName, int sol)
        {
            var cameraDataDto = await _dataService.GetAsync<CameraDataDto>(photosUrl.Replace("{ROVERNAME}", roverName).Replace("{SOL}", sol.ToString()));

            if (cameraDataDto == null && cameraDataDto.Photos == null || cameraDataDto.Photos.Count() <= 0)
                return Result.Fail<IEnumerable<Photo>>("Network problems. Please try again later.");

            return Result.Ok(cameraDataDto.Photos);
        }
    }
}
