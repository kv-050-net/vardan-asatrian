using BaseOOPDAL.Entities;
using BaseOOPDAL.Interfaces;
using System.Collections.Generic;

namespace BaseOOPDAL.Repositories
{
    public class DesignerRepository : IRepository<Designer>
    {
        private readonly Context _context;

        public DesignerRepository(Context context)
        {
            _context = context;
        }

        public void Create(Designer item)
        {
            _context.Designers.Add(item);
        }

        public Designer Read(int id)
        {
            return _context.Designers.Find(id);
        }

        public IEnumerable<Designer> ReadAll()
        {
            return _context.Designers;
        }

        public void Update(Designer item)
        {
            _context.Designers.Update(item);
        }

        public void Delete(int id)
        {
            var designer = _context.Designers.Find(id);

            if(designer != null)
                _context.Designers.Remove(designer);
        }
    }
}
