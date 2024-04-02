using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSln.Application.Bases
{
	public class BaseExcepiton : ApplicationException
	{
		public BaseExcepiton()
		{

		}
		public BaseExcepiton(string message) : base(message)
		{

		}
	}
}
