using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DbContextExtentions
    {
		public static ObjectContext ToObjectContext(this DbContext dbContext)
		{
			return (dbContext as IObjectContextAdapter).ObjectContext;
		}
    }
}
