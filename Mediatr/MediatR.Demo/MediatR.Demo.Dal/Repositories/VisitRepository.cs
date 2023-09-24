using MediatR.Demo.Dal.Database;
using MediatR.Demo.Dal.Entities;
using MediatR.Demo.Dal.Infrastructure.Filters;
using MediatR.Demo.Dal.Repositories.Interfaces;
using MediatR.Demo.Framework.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MediatR.Demo.Dal.Repositories;

public class VisitRepository : GenericRepository<Visit>, IVisitRepository
{
    public VisitRepository(DemoDbContext context) : base(context)
    {
    }

    public async Task<Visit?> GetVisitByVisitorEmail(string email, CancellationToken cancellationToken)
    {
        var visit = await Set.FirstOrDefaultAsync(x =>  x.Visitor.Email == email, cancellationToken);
        return visit;
    }

    public async Task<IReadOnlyCollection<Visit>> GetOpenVisits(CancellationToken cancellationToken)
    {
        var visits = await Set
            .Include(x=> x.Company)
            .Include(x=>x.Visitor)
            .Include(x=> x.Employee).Where(x => x.Stop == null).ToListAsync(cancellationToken);
        return visits;
    }

    public async Task<IReadOnlyCollection<Visit>> GetVisits(VisitFilter filter, CancellationToken cancellationToken)
    {
        var query = Set.Include(x => x.Company)
            .Include(x => x.Visitor)
            .Include(x => x.Employee).AsQueryable();

        if (!filter.VisitorName.IsNullEmptyOrWhiteSpace())
            query = query.Where(x => x.Visitor.Name != null && x.Visitor.Name.Contains(filter.VisitorName));
        if (!filter.VisitorEmail.IsNullEmptyOrWhiteSpace())
            query = query.Where(x => x.Visitor.Email != null && x.Visitor.Email.Contains(filter.VisitorEmail));
        if (!filter.VisitorCompany.IsNullEmptyOrWhiteSpace())
            query = query.Where(x => x.Visitor.Company != null && x.Visitor.Company.Contains(filter.VisitorCompany));
        if (!filter.Company.IsNullEmptyOrWhiteSpace())
            query = query.Where(x => x.Company.Name != null && x.Company.Name.Contains(filter.Company));
        if (!filter.Employee.IsNullEmptyOrWhiteSpace())
            query = query.Where(x => x.Employee.Name != null && x.Employee.Name.Contains(filter.Employee));



        return await query.ToListAsync(cancellationToken);
    }

}