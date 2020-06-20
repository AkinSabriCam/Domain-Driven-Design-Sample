using Exercise.Domain.Companies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exercise.EntityFramework.EntityFrameworkCore.Companies
{
    public class EfCompanyRepository : BaseRepository<Company, Guid>, ICompanyRepository
    {
        public EfCompanyRepository(IDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IList<Company>> GetListWithDetailsAsync()
        {
            var companies = GetQueryable();
            companies = companies.Include(x => x.Busses);
           
            return await companies.ToListAsync();
        }

        public async Task<Company> GetWithDetailsAsync(Guid id)
        {
            var companies = GetQueryable();
            companies = companies.Include(x => x.Busses);

            return await companies.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
