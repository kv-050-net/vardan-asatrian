using System.Threading.Tasks;
using AutoMapper;
using BaseOOPBLL.Entities;
using BaseOOPDAL.Entities;
using BaseOOPDAL.Interfaces;

namespace BaseOOPBLL.Services.DeveloperService
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public DeveloperService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateOrUpdateAsync(DeveloperDto developerDto)
        {
            var developer = _mapper.Map<Developer>(developerDto);

            await _uow.Developers.CreateOrUpdateAsync(developer);
            await _uow.CommitAsync();
        }
    }
}
