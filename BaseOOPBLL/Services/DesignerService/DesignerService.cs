using System.Collections.Generic;
using AutoMapper;
using BaseOOPBLL.Entities;
using BaseOOPDAL.Entities;
using BaseOOPDAL.Interfaces;

namespace BaseOOPBLL.Services.DestignerService
{
    public class DesignerService : IDesignerService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _db;

        public DesignerService(IMapper mapper, IUnitOfWork db)
        {
            _mapper = mapper;
            _db = db;

        }

        public void Create(DesignerDto des)
        {
            var manager = _mapper.Map<Manager>(des.Manager);

            var designer = _mapper.Map<Designer>(des);

            designer.Manager = manager;

            _db.Designers.Create(designer);

            _db.Save();
        }

        public void Delete(int id)
        {
            _db.Designers.Delete(id);

            _db.Save();
        }

        public DesignerDto Read(int id)
        {
            var designer = _db.Designers.Read(id);

            _db.Save();

            return _mapper.Map<DesignerDto>(designer);
        }

        public IEnumerable<DesignerDto> ReadAll()
        {
            var designers = _db.Designers.ReadAll();

            _db.Save();

            return _mapper.Map<IEnumerable<DesignerDto>>(designers);
        }

        public void Update(DesignerDto des)
        {
            var designer = _db.Designers.Read(des.Id);

            if (designer != null)
            {
                var manager = _mapper.Map<Manager>(des.Manager);

                designer = _mapper.Map<Designer>(des);

                designer.Manager = manager;

                _db.Designers.Update(designer);

                _db.Save();
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
