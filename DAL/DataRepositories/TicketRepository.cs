using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DomainModel;

namespace DAL.DataRepositories
{
	public class TicketRepository : GenericDataRepository<Ticket>, ITicketRepository
	{
	}
}
