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

	public partial class Range : IEntity
	{
		public int Id { get; set; }
		public int Interval { get; set; }

		public virtual Doctor Doctor { get; set; }
		public EntityState EntityState { get; set; }
	}
}
