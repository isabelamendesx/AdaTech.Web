using PropertiesAPI.Data.Repositories;
using PropertiesAPI.Models;
using System.Runtime.CompilerServices;

namespace PropertiesAPI.Services
{
    public interface IPropertyService
    {
        void Register(Property property);
        IEnumerable<Property> GetProperties();
        Property? GetById(int Id);
        void Update(Property originalProperty, Property updatedProperty);

        void Delete(Property property);
    }
    public class PropertyService : IPropertyService
    {
        private readonly IRepository<Property> _repository;

        public PropertyService(IRepository<Property> repository)
        {
            _repository = repository;
        }

        public void Register(Property property)
        {
            _repository.Add(property);
        }

        public IEnumerable<Property> GetProperties()
        {
            return _repository.GetAll();
        }

        public Property? GetById(int Id)
        {
            return _repository.GetById(Id);
        }

        public void Update(Property originalEntity, Property updatedProperty)
        {
            _repository.Update(originalEntity, updatedProperty);
        }

        public void Delete(Property property)
        {
            _repository.Delete(property);
        }
    }
}
