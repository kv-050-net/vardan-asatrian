using System.Threading.Tasks;
using AutoMapper;
using BaseOOPBLL.Entities;
using BaseOOPDAL.Entities;
using BaseOOPDAL.Interfaces;

namespace BaseOOPBLL.Services.ManagerService
{
    public class ManagerService : IManagerService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ManagerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateOrUpdateAsync(ManagerDto managerDto)
        {
            var manager = _mapper.Map<Manager>(managerDto);

            await _uow.Managers.CreateOrUpdateAsync(manager);
            await _uow.CommitAsync();
        }
    }
}
