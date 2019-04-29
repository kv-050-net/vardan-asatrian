using System.Collections.Generic;
using AutoMapper;
using BaseOOPBLL.Entities;
using BaseOOPDAL.Entities;
using BaseOOPDAL.Interfaces;

namespace BaseOOPBLL.Services.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _db;

        public DepartmentService(IMapper mapper, IUnitOfWork db)
        {
            _mapper = mapper;
            _db = db;
        }

        public void Create(DepartmentDto dep)
        {
            var managers = _mapper.Map<List<Manager>>(dep.Managers);

            var department = _mapper.Map<Department>(dep);

            department.Managers = managers;

            _db.Departments.Create(department);

            _db.Save();
        }

        public void Delete(int id)
        {
            _db.Departments.Delete(id);

            _db.Save();
        }

        public DepartmentDto Read(int id)
        {
            var department = _db.Departments.Read(id);

            _db.Save();

            return _mapper.Map<DepartmentDto>(department);
        }

        public IEnumerable<DepartmentDto> ReadAll()
        {
            var department = _db.Departments.ReadAll();

            _db.Save();

            return _mapper.Map<IEnumerable<DepartmentDto>>(department);
        }

        public void Update(DepartmentDto dep)
        {
            var department = _db.Departments.Read(dep.Id);

            if (department != null)
            {
                var managers = _mapper.Map<List<Manager>>(dep.Managers);

                department = _mapper.Map<Department>(dep);

                department.Managers = managers;

                _db.Departments.Update(department);

                _db.Save();
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void PaySalary()
        {
            throw new System.NotImplementedException();
        }

        public void AccrueSalary(EmployeeDto employeeDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
