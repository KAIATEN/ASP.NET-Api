using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Application.Bases
{
	public class BaseExcepitons : ApplicationException
	{
		public BaseExcepitons()
		{

		}
		public BaseExcepitons(string message) : base(message)
		{

		}
	}
}
