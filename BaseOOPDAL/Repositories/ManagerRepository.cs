using BaseOOPDAL.Entities;
using BaseOOPDAL.Interfaces;
using System.Collections.Generic;

namespace BaseOOPDAL.Repositories
{
    public class ManagerRepository : IRepository<Manager>
    {
        private Context _context;

        public ManagerRepository(Context context)
        {
            _context = context;
        }

        public void Create(Manager item)
        {
            _context.Managers.Add(item);
        }

        public Manager Read(int id)
        {
            return _context.Managers.Find(id);
        }

        public IEnumerable<Manager> ReadAll()
        {
            return _context.Managers;
        }

        public void Update(Manager item)
        {
            _context.Managers.Update(item);
        }

        public void Delete(int id)
        {
            var manager = _context.Managers.Find(id);

            if(manager != null)
                _context.Managers.Remove(manager);
        }
    }
}
