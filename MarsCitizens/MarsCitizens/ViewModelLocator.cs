using Microsoft.Practices.Unity;
using Microsoft.Practices.ServiceLocation;
using MarsCitizens.Contracts.Repository;
using MarsCitizens.Contracts.Services;
using MarsCitizens.Repositories;
using MarsCitizens.Services;
using MarsCitizens.ViewModels;


namespace MarsCitizens
{
    public class ViewModelLocator
    {
        private readonly IUnityContainer _unityContainer;

        public MainViewModel MainViewModel => _unityContainer.Resolve<MainViewModel>();

        public CitizensViewModel CitizensViewModel => _unityContainer.Resolve<CitizensViewModel>();

        public CitizenDetailViewModel CitizenDetailViewModel => _unityContainer.Resolve<CitizenDetailViewModel>();

        public PhotosListViewModel PhotosListViewModel => _unityContainer.Resolve<PhotosListViewModel>();

        public ViewModelLocator()
        {
            _unityContainer = new UnityContainer()
                 .RegisterType<IDataService, DataService>()
                 .RegisterType<ICitizensRepository, CitizensRepository>()
                 .RegisterType<IPhotoCameraRepository, PhotoCameraRepository>()
                 .RegisterType<MainViewModel>(new ContainerControlledLifetimeManager())
                 .RegisterType<CitizensViewModel>(new ContainerControlledLifetimeManager())
                 .RegisterType<CitizenDetailViewModel>(new ContainerControlledLifetimeManager())
                 .RegisterType<PhotosListViewModel>(new ContainerControlledLifetimeManager());

            var unityServiceLocator = new UnityServiceLocator(_unityContainer);

            ServiceLocator.SetLocatorProvider(() => unityServiceLocator);
        }
    }
}
