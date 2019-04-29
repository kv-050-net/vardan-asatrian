using BaseOOPDAL.Entities;
using BaseOOPDAL.Interfaces;
using System.Collections.Generic;

namespace BaseOOPDAL.Repositories
{
    public class DeveloperRepository : IRepository<Developer>
    {
        private Context _context;

        public DeveloperRepository(Context context)
        {
            _context = context;
        }

        public void Create(Developer item)
        {
            _context.Developers.Add(item);
        }

        public Developer Read(int id)
        {
            return _context.Developers.Find(id);
        }

        public IEnumerable<Developer> ReadAll()
        {
            return _context.Developers;
        }

        public void Update(Developer item)
        {
            _context.Developers.Update(item);
        }

        public void Delete(int id)
        {
            var developer = _context.Developers.Find(id);

            if(developer != null)
                _context.Developers.Remove(developer);
        }
    }
}
