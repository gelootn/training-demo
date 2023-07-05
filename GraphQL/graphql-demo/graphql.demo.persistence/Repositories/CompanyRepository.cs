using graphql.demo.persistence.Database;
using graphql.demo.persistence.Entities;
using graphql.demo.persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace graphql.demo.persistence.Repositories;

public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
{


    public CompanyRepository(DemoDbContext context) : base(context)
    {

    }
    async Task<IReadOnlyCollection<Company>> ICompanyRepository.GetCompanies()
    {
        return await Set.Include(x=> x.Employees).ToListAsync();
    }

    async Task<Company?> ICompanyRepository.GetCompany(int id, CancellationToken cancellationToken)
    {
        var company = await Set.Include(x=> x.Employees).FirstOrDefaultAsync(x=> x.Id == id, cancellationToken);
        return company;
    }
}