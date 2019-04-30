using System.Collections.Generic;
using AutoMapper;
using BaseOOPBLL.Entities;
using BaseOOPDAL.Entities;
using BaseOOPDAL.Interfaces;

namespace BaseOOPBLL.Services.ManagerService
{
    public class ManagerService : IManagerService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _db;

        public ManagerService(IMapper mapper, IUnitOfWork db)
        {
            _mapper = mapper;
            _db = db;
        }

        public void Create(ManagerDto man)
        {
            var manager = _mapper.Map<Manager>(man.Manager);

            var department = _mapper.Map<Department>(man.Department);

            var developers = _mapper.Map<List<Developer>>(man.DevelopersTeam);

            var designers = _mapper.Map<List<Designer>>(man.DesignersTeam);

            var managers = _mapper.Map<List<Manager>>(man.ManagersTeam);

            var newManager = _mapper.Map<Manager>(man);

            newManager.Manager = manager;

            newManager.Department = department;

            newManager.DesignersTeam = designers;

            newManager.DevelopersTeam = developers;

            newManager.ManagersTeam = managers;

            _db.Managers.Create(newManager);

            _db.Save();
        }

        public void Delete(int id)
        {
            _db.Managers.Delete(id);

            _db.Save();
        }

        public ManagerDto Read(int id)
        {
            var manager = _db.Managers.Read(id);

            _db.Save();

            return _mapper.Map<ManagerDto>(manager);
        }

        public IEnumerable<ManagerDto> ReadAll()
        {
            var managers = _db.Managers.ReadAll();

            _db.Save();

            return _mapper.Map<IEnumerable<ManagerDto>>(managers);
        }

        public void Update(ManagerDto man)
        {
            var newManager = _db.Managers.Read(man.Id);

            if (newManager != null)
            {
                var manager = _mapper.Map<Manager>(man.Manager);

                var department = _mapper.Map<Department>(man.Department);

                var developers = _mapper.Map<List<Developer>>(man.DevelopersTeam);

                var designers = _mapper.Map<List<Designer>>(man.DesignersTeam);

                var managers = _mapper.Map<List<Manager>>(man.ManagersTeam);

                newManager = _mapper.Map<Manager>(man);

                newManager.Manager = manager;

                newManager.Department = department;

                newManager.DesignersTeam = designers;

                newManager.DevelopersTeam = developers;

                newManager.ManagersTeam = managers;

                _db.Managers.Update(newManager);

                _db.Save();
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
