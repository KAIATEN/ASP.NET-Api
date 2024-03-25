using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Domain.Entities.Common
{
	public class BaseEntity : IBaseEntity
	{
		public Guid Id { get; set; }
		public DateTime CreateDate { get; set; } = DateTime.Now;
		public virtual DateTime? ModifiedDate { get; set; }
	}
}
