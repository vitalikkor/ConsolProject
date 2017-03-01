using System;
namespace ConsolProject
{
	public abstract class IViewPresentingDataRow
	{
		//public abstract PresentingRowType presentingRowType { get; set;}

		//this id should be unique getting from searching results
		public abstract string getId();

		//article getting from searching results
		public abstract string getArticle();

		//article getting from searching results
		public abstract string getName();

		public abstract float getUnitPrice();

		public abstract float getDiscount();

		public abstract string getUsersNotes();

		public abstract float getQuantity();

		public abstract float getMultiplier();


		public int getMultipleQuantity()
		{ 
			return Convert.ToInt32(getQuantity()*getMultiplier());
		}

		public virtual float getPricePerQuantity()
		{
			return getQuantity()*getUnitPrice();
		}

		public virtual float getMultiplePrice()
		{
			return getMultipleQuantity() * getUnitPrice();
		}

		public virtual float getDiscountPrice()
		{
			return getUnitPrice()*(1-getDiscount())/100;
		}

		public virtual float getMultipleDiscountPrice()
		{
			return getMultipleQuantity() * getUnitPrice() * (1 - getDiscount()) / 100;
		}
	}
}
