using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.EntityClient;

namespace Patholab_DAL_V1
{
    public partial class Entities : DbContext
    {
        public Entities(string cs)
            : base(cs)
        {
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 180; // seconds

        }

        public Entities(EntityConnection connection) :
            base(connection, true)
        {

            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 180; // seconds
        }
    }
}