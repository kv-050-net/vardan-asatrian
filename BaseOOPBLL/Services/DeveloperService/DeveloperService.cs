using System.Collections.Generic;
using AutoMapper;
using BaseOOPBLL.Entities;
using BaseOOPDAL;
using BaseOOPDAL.Entities;
using BaseOOPDAL.Interfaces;

namespace BaseOOPBLL.Services.DeveloperService
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IUnitOfWork _db;

        public DeveloperService()
        {
            _db = new UnitOfWork();
        }

        public void Create(DeveloperDto dev)
        {
            var manager = Mapper.Map<Manager>(dev.Manager);

            var developer = Mapper.Map<Developer>(dev);

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

            return Mapper.Map<DeveloperDto>(developer);
        }

        public IEnumerable<DeveloperDto> ReadAll()
        {
            var developers = _db.Developers.ReadAll();

            _db.Save();

            return Mapper.Map<IEnumerable<DeveloperDto>>(developers);
        }

        public void Update(DeveloperDto dev)
        {
            var developer = _db.Developers.Read(dev.Id);

            if (developer != null)
            {
                var manager = Mapper.Map<Manager>(dev.Manager);

                developer = Mapper.Map<Developer>(dev);

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
