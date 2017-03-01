using System;
namespace ConsolProject
{
	public class ElementPresentingDataRow : IViewPresentingDataRow
	{
		protected PresentingRowType presentingRowType { get; set;} = PresentingRowType.element;
		protected string id { get; set;}
		protected string name { get; set;}
		protected string article { get; set;}
		protected float price { get; set;}
		protected float discount { get; set;}
		protected float quantity { get; set;}
		protected float multiplier { get; set;}
		protected string usersNotes { get; set;}

		public ElementPresentingDataRow(String id, String article, String name, float quantity = 1, float price = 0,
		                                float multiplier = 1, float discount = 0, String usersNotes = "")
		{
				this.id = id;
				this.name = name;
				this.article = article;
				this.price = price;
				this.discount = discount;
				this.quantity = quantity;
				this.multiplier = multiplier;
				this.usersNotes = usersNotes;
		}

		public override string getId()
		{
			return id;
		}

		//article getting from searching results
		public override string getArticle()
		{
			return article;
		}

		//article getting from searching results
		public override string getName()
		{
			return name;
		}

		public override float getUnitPrice()
		{
			return price;
		}

		public override float getDiscount()
		{
			return discount;
		}

		public override string getUsersNotes()
		{
			return usersNotes;
		}

		public override float getQuantity()
		{
			return quantity;
		}

		public override float getMultiplier()
		{
			return multiplier;
		}
	}
}
