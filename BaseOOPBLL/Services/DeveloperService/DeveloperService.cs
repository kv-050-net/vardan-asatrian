using System.Collections.Generic;
using AutoMapper;
using BaseOOPBLL.Entities;
using BaseOOPDAL.Entities;
using BaseOOPDAL.Interfaces;

namespace BaseOOPBLL.Services.DeveloperService
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _db;

        public DeveloperService(IMapper mapper, IUnitOfWork db)
        {
            _mapper = mapper;
            _db = db;
        }

        public void Create(DeveloperDto dev)
        {
            var manager = _mapper.Map<Manager>(dev.Manager);

            var developer = _mapper.Map<Developer>(dev);

            developer.Manager = manager;

            _db.Developers.Create(developer);

            _db.Save();
        }

        public void Delete(int id)
        {
            _db.Developers.Delete(id);

            _db.Save();
        }

        public DeveloperDto Read(int id)
        {
            var developer = _db.Developers.Read(id);

            _db.Save();

            return _mapper.Map<DeveloperDto>(developer);
        }

        public IEnumerable<DeveloperDto> ReadAll()
        {
            var developers = _db.Developers.ReadAll();

            _db.Save();

            return _mapper.Map<IEnumerable<DeveloperDto>>(developers);
        }

        public void Update(DeveloperDto dev)
        {
            var developer = _db.Developers.Read(dev.Id);

            if (developer != null)
            {
                var manager = _mapper.Map<Manager>(dev.Manager);

                developer = _mapper.Map<Developer>(dev);

                developer.Manager = manager;

                _db.Developers.Update(developer);

                _db.Save();
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
