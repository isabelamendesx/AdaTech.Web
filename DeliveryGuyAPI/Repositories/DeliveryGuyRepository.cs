using DeliveryGuyAPI.Data;
using DeliveryGuyAPI.Models;

namespace DeliveryGuyAPI.Repositories
{
    public class DeliveryGuyRepository : IRepository<DeliveryGuy>
    {
        private readonly DeliveryGuyContext _context;

        public DeliveryGuyRepository(DeliveryGuyContext context)
        {
            _context = context;
        }

        public void Add(DeliveryGuy entity)
        {
            _context.DeliveryGuys.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(DeliveryGuy entity)
        {
            _context.DeliveryGuys.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<DeliveryGuy> GetAll()
        {
            return _context.DeliveryGuys;
        }

        public DeliveryGuy? GetById(int id)
        {
            return _context.DeliveryGuys.FirstOrDefault(dg => dg.Id == id);
        }

        public void Update(DeliveryGuy originalDGuy, DeliveryGuy updatedDGuy)
        {
            if(originalDGuy != null)
            {

            }
        }
    }
}
