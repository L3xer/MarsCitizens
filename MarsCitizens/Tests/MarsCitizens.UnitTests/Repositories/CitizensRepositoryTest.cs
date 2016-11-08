using System.Threading.Tasks;
using System.Collections.Generic;
using NUnit.Framework;
using MarsCitizens.Contracts.Repository;
using MarsCitizens.Contracts.Services;
using MarsCitizens.Models;
using MarsCitizens.Repositories;


namespace MarsCitizens.UnitTests.Repositories
{
    [TestFixture]
    public class CitizensRepositoryTest
    {
        private ICitizensRepository defaultRepository;
        private ICitizensRepository emptyRepository;

        [SetUp]
        public void SetUp()
        {
            defaultRepository = new CitizensRepository(new DataServiceStub());
            emptyRepository = new CitizensRepository(new EmptyDataServiceStub());
        }

        [Test]
        public async Task CitizensRepository_GetAll_ReturnsList()
        {
            var result = await defaultRepository.GetAllAsync();

            Assert.That(result.IsSuccess, Is.True);
        }

        [Test]
        public async Task CitizensRepository_GetAll_FailsIfDataServiceIsEmpty()
        {
            var result = await emptyRepository.GetAllAsync();

            Assert.That(result.IsFailure, Is.True);
        }

        [Test]
        public async Task CitizensRepository_GetCount_ReturnsCountOfCitizens()
        {
            var result = await defaultRepository.GetCountAsync();

            Assert.That(result.Value, Is.EqualTo(2));
        }

        [Test]
        public async Task CitizensRepository_GetCount_FailsIfDataServiceIsEmpty()
        {
            var result = await emptyRepository.GetCountAsync();

            Assert.That(result.IsFailure, Is.True);
        }

        private class DataServiceStub : IDataService
        {
            public Task<T> GetAsync<T>(string url) where T : new()
            {
                return Task.FromResult((T)(object)new List<Citizien>() {
                    new Citizien { Name = "First" },
                    new Citizien { Name = "Second" }
                });
            }
        }

        private class EmptyDataServiceStub : IDataService
        {
            public Task<T> GetAsync<T>(string url) where T : new() => Task.FromResult(new T());
        }
    }
}
