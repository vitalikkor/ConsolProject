using System;
namespace ConsolProject
{
	public abstract class IViewPresentingDataRow
	{
		public abstract PresentingRowType presentingRowType { get; set;}

		//this id should be unique getting from searching results
		public abstract string id { get; }

		//article getting from searching results
		public abstract string article { get; }

		//article getting from searching results
		public abstract string name { get; }

		public float price { get; set; } = 0;
		public float discount { get; set; } = 0;
		public string usersNotes { get; set; } = "";
		public float quantity { get; set; } = 1;
		public int multiplier { get; set; } = 1;

		public int multipleQuantity
		{ get
			{
				return Convert.ToInt32(quantity*multiplier);
			}
		}

		public virtual float getPrice()
		{
			return quantity*price;
		}
		public virtual float getMultiplePrice()
		{
			return multipleQuantity * price;
		}
		public virtual float getDiscountPrice()
		{
			return price*discount/100;
		}
		public virtual float getMultipleDiscountPrice()
		{
			return multiplier * price * discount / 100;
		}
	}
}
