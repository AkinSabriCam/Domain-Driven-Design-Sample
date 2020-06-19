using AutoMapper;
using Exercise.EntityFramework.EntityFrameworkCore.UoW;

namespace Exercise.Application.Contracts
{
    public interface IBaseAppService
    {
        IMapper ObjectMapper { get; set; }

        IUnitOfWork UnitOfWork { get; set; }
    }
}
