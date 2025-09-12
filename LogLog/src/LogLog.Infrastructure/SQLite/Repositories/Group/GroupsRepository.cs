using LogLog.Domain.Entities;
using LogLog.Domain.Interfaces.Repositories;
using LogLog.Infrastructure.SqlLite;

namespace LogLog.Infrastructure.SQLite.Repositories.Group
{
    public class GroupsRepository : Repository<GroupEntity>, IGroupsRepository
    {
        public GroupsRepository(SQLiteDbContext context) : base(context)
        {
        }
    }
}
