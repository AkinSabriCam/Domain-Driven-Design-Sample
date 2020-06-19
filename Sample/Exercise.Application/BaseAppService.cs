using AutoMapper;
using Exercise.Application.Contracts;
using Exercise.EntityFramework.EntityFrameworkCore.UoW;

namespace Exercise.Application
{
    public class BaseAppService : IBaseAppService
    {
        public IMapper ObjectMapper { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }

        public BaseAppService(IMapper objectMapper, IUnitOfWork unitOfWork)
        {
            ObjectMapper = objectMapper;
            UnitOfWork = unitOfWork;
        }
    }
}
