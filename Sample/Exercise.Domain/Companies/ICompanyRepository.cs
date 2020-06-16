using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Domain.Companies
{
    public interface ICompanyRepository : IBaseRepository<Company, Guid>
    {
        Task<IList<Company>> GetListWithDetails();

        Task<Company> GetWithDetailsById(Guid id);

    }
}
