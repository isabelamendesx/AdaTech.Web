using PropertiesAPI.Models;
using System.Diagnostics;

namespace PropertiesAPI.Data.Repositories
{
    public class PropertyRepository : IRepository<Property>
    {
        private readonly PropertyContext _context;

        public PropertyRepository(PropertyContext context)
        {
            _context = context;
        }

        public void Add(Property property)
        {
            _context.Properties.Add(property);
            _context.SaveChanges();
        }

        public void Delete(Property property)
        {
            _context.Properties.Remove(property);
        }

        public IEnumerable<Property> GetAll()
        {
            return _context.Properties;
        }

        public Property? GetById(int id)
        {
            return _context.Properties.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Property originalProperty, Property updatedProperty)
        {
            if (originalProperty != null)
            {
                originalProperty.Type = updatedProperty.Type;
                originalProperty.Price = updatedProperty.Price; 
                originalProperty.AreaSize = updatedProperty.AreaSize;   
                _context.SaveChanges();
            }
        }
    }
}
