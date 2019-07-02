using System.Threading.Tasks;
using AutoMapper;
using BaseOOPBLL.Entities;
using BaseOOPDAL.Entities;
using BaseOOPDAL.Interfaces;

namespace BaseOOPBLL.Services.DestignerService
{
    public class DesignerService : IDesignerService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public DesignerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateOrUpdateAsync (DesignerDto designerDto)
        {
            var designer = _mapper.Map<Designer>(designerDto);

            await _uow.Designers.CreateOrUpdateAsync(designer);
            await _uow.CommitAsync();
        }
    }
}
