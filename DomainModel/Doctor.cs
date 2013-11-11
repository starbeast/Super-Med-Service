//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DomainModel
{
    using System;
    using System.Collections.Generic;

	public partial class Doctor : IEntity
	{
		public Doctor()
		{
			this.Tickets = new HashSet<Ticket>();
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public int DepartmentId { get; set; }
		public int EmergencyCounter { get; set; }
		public bool isEven { get; set; }
		public int RangeId { get; set; }

		public virtual Department Department { get; set; }
		public virtual Range Range { get; set; }
		public virtual ICollection<Ticket> Tickets { get; set; }
		public EntityState EntityState { get; set; }
	}
}
