using graphql.demo.persistence.Database;
using graphql.demo.persistence.Entities;
using graphql.demo.persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace graphql.demo.persistence.Repositories;

public class VisitorRepository : GenericRepository<Visitor>, IVisitorRepository 
{
    public VisitorRepository(DemoDbContext context) : base(context)
    {
    }

    public async Task<Visitor?> GetVisitorByEmail(string email, CancellationToken cancellationToken)
    {
       var visitor = await Set.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
       return visitor;
    }
}