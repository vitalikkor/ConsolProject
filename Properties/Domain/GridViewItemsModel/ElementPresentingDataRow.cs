using System;
namespace ConsolProject
{
	public class ElementPresentingDataRow : IViewPresentingDataRow
	{
		private String name;
		private String article;
		private float price;
		private float discount;
		private int quantity;
		private int multiplier;
		private String description;
		protected PresentingRowType presentingStile;


		public ElementPresentingDataRow(String article, String name, int quantity = 1, float price = 0,
										int multiplier = 1, float discount = 0, String description = "")
		{
			this.name = name;
			this.article = article;
			this.price = price;
			this.discount = discount;
			this.quantity = quantity;
			this.multiplier = multiplier;
			this.description = description;
		}

		public override PresentingRowType getPresentingRowType()
		{
			return this.presentingStile;
		}

		public override String getName()
		{
			return this.name;
		}

		public override string getArticle()
		{
			return this.article;
		}

		public override string getPrice()
		{
			return this.price.ToString();
		}

		public override string getDiscount()
		{
			return this.discount.ToString();
		}

		public override string getQuantity()
		{
			return this.quantity.ToString();
		}

		public override string getMultipleQuantity()
		{
			return (this.multiplier*this.quantity).ToString();
		}

		public override string getMultiplePrice()
		{
			return (this.price*this.multiplier).ToString();
		}

		public override string getDiscountPrice()
		{
			return (this.price*discount/100).ToString();
		}

		public override string getMultipleDiscountPrice()
		{
			return (this.price * this.quantity * discount / 100).ToString();
		}

		public override string getDescription()
		{
			return this.description;
		}

	}
}
