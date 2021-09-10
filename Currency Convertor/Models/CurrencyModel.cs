using System;
using System.Collections.Generic;
using System.Text;

namespace Currency_Convertor.Models
{
	public class CurrencyModel
	{
		/// <summary>
		/// Initialize variables
		/// </summary>
		public float Num1 { get; set; }
		public float Num50c { get; set; }
		public float Num10c { get; set;  }
		public float Num5c { get; set; }

		/// <summary>
		/// Create a default constructor
		/// </summary>
		public CurrencyModel()
		{
			Num1 = 0;
			Num50c = 0;
			Num10c = 0;
			Num5c = 0;
			
		}


		public void AddOne()
		{
			Num1 ++;

		}


		public void Add50c()
		{
			Num50c ++;

		}

		public void Add5c()
		{
			Num5c++;

		}

		public void Add10c()
		{
			Num10c ++;

			
		}



		public void Subtract1()
		{
			if(Num1 > 0)
			{
				Num1--;
			}
			
		}


		public void Subtract50c()
		{
			if(Num50c > 0)
			{
				Num50c--;
			}
			
		}

		public void Subtract10c()
		{
			if(Num10c > 0)
			{
				Num10c--;
			}
			
		}

		public void Subtract5c()
		{
			if(Num5c > 0)
			{
				Num5c--;
			}
			
		}

		public void Downdollar()
		{
			if(Num1 > 0)
			{
				Num1--;
				Num50c += 2;
			}
			
		}

		public void Down50c()
		{
			if(Num50c > 0)
			{
				Num50c--;
				Num10c += 5;
			}
			
		}
		

		public void Down10c()
		{
			if(Num10c > 0)
			{
				Num10c--;
				Num5c += 2;
			}
			
		}
		

		public void Up5c()
		{
			if(Num5c >= 2)
			{
				Num5c -= 2;
				Num10c++;

			}
			
		}

		public void Up10c()
		{
			if(Num10c >= 5)
			{
				Num10c -= 5;
				Num50c++;
			}
			
		}
		public void Up50c()
		{
			if(Num50c >= 2)
			{
				Num50c -= 2;
				Num1++;
			}
			
		}

	}
}
