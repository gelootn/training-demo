using Dapper.Demo.Dal.Database;
using Dapper.Demo.Dal.Entities;
using Dapper.Demo.Dal.Repositories.Interfaces;


namespace Dapper.Demo.Dal.Repositories;

public class VisitorRepository : GenericRepository<Visitor>, IVisitorRepository 
{
    public VisitorRepository(DapperContext context) : base(context)
    {
    }

    public async Task<Visitor?> GetVisitorByEmail(string email, CancellationToken cancellationToken)
    {
       //var visitor = await Set.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
       //return visitor;

        throw new NotImplementedException();

    }
}