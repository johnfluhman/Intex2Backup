using System;
using System.Linq;

namespace CollisionsDB.Models
{
    public class EFCollisionRepository : ICollisionRepository
    {
        private CollisionDBContext _context { get; set; }

        public EFCollisionRepository(CollisionDBContext temp)
        {
            _context = temp;
        }

        public IQueryable<Collision> Collisions => _context.Collisions;
        public IQueryable<City> Cities => _context.Cities;
        public IQueryable<County> Counties => _context.Counties;

        public void AddCollision(Collision collision)
        {
            _context.Collisions.Add(collision);
            _context.SaveChanges();
        }
        public void DeleteCollision(Collision collision)
        {
            _context.Collisions.Remove(collision);
            _context.SaveChanges();
        }
        public void EditCollision(Collision collision)
        {
            _context.Collisions.Update(collision);
            _context.SaveChanges();
        }
    }
}
