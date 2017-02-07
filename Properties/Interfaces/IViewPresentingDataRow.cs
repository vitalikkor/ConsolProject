using System;
namespace ConsolProject
{
	public abstract class IViewPresentingDataRow
	{
		public abstract PresentingRowType getPresentingRowType();

		public virtual String getArticle()
		{
			return String.Empty;
		}
		public virtual String getName()
		{
			return String.Empty;
		}
		public virtual String getDescription()
		{
			return String.Empty;
		}
		public virtual  String getQuantity()
		{
			return String.Empty;
		}
		public virtual  String getMultipleQuantity()
		{
			return String.Empty;
		}
		public virtual  String getDiscount()
		{
			return String.Empty;
		}
		public virtual  String getPrice()
		{
			return String.Empty;
		}
		public virtual  String getMultiplePrice()
		{
			return String.Empty;
		}
		public virtual String getDiscountPrice()
		{
			return String.Empty;
		}
		public virtual String getMultipleDiscountPrice()
		{
			return String.Empty;
		}
	}
}
