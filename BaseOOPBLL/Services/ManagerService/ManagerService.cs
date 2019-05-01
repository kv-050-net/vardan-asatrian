using System.Collections.Generic;
using AutoMapper;
using BaseOOPBLL.Entities;
using BaseOOPDAL;
using BaseOOPDAL.Entities;
using BaseOOPDAL.Interfaces;

namespace BaseOOPBLL.Services.ManagerService
{
    public class ManagerService : IManagerService
    {
        private readonly IUnitOfWork _db;

        public ManagerService()
        {
            _db = new UnitOfWork();
        }

        public void Create(ManagerDto man)
        {
            var manager = Mapper.Map<Manager>(man.Manager);

            var department = Mapper.Map<Department>(man.Department);

            var employees = Mapper.Map<List<Employee>>(man.Team);

            var newManager = Mapper.Map<Manager>(man);

            newManager.Manager = manager;

            newManager.Department = department;

            newManager.Team = employees;

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

            return Mapper.Map<ManagerDto>(manager);
        }

        public IEnumerable<ManagerDto> ReadAll()
        {
            var managers = _db.Managers.ReadAll();

            _db.Save();

            return Mapper.Map<IEnumerable<ManagerDto>>(managers);
        }

        public void Update(ManagerDto man)
        {
            var newManager = _db.Managers.Read(man.Id);

            if (newManager != null)
            {
                var manager = Mapper.Map<Manager>(man.Manager);

                var department = Mapper.Map<Department>(man.Department);

                var employees = Mapper.Map<List<Employee>>(man.Team);

                newManager = Mapper.Map<Manager>(man);

                newManager.Manager = manager;

                newManager.Department = department;

                newManager.Team = employees;

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
