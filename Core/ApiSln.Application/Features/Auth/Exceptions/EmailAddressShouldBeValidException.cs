using ApiSln.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Application.Features.Auth.Exceptions
{
	public class EmailAddressShouldBeValidException : BaseExcepiton
	{
		public EmailAddressShouldBeValidException() : base("Böyle bir email adresi yok.")
		{

		}
	}
}
