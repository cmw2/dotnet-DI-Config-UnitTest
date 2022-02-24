/* This Sample Code is provided for the purpose of illustration only 
 * and is not intended to be used in a production environment.   
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math
{
    public class Math
    {
		public int Add(int oper1, int oper2)
		{
			return oper1 + oper2;
		}

		public int Divide(int oper1, int oper2)
		{
			if (oper2 == 0)
			{
				throw new ArgumentOutOfRangeException("oper2", "oper2 cannot be 0");
			}

			return oper1 / oper2;
		}

		public int Subtract(int oper1, int oper2)
		{
			return oper1 - oper2;
		}

		public double GetPi(int sigDigits)
		{
			if (sigDigits == 1)
			{
				return 3;
			}
			else if (sigDigits == 2)
			{
				return 3.1;
			}
			else if (sigDigits == 3)
			{
				return 3.14;
			}
			else
			{
				return 3.142;
			}
		}
	}
}
