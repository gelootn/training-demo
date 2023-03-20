using MediatR.Demo.Dal.Database;
using MediatR.Demo.Dal.Entities;
using MediatR.Demo.Dal.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediatR.Demo.Dal.Repositories;

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