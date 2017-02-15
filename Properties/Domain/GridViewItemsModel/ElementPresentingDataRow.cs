using System;
namespace ConsolProject
{
	public class ElementPresentingDataRow : IViewPresentingDataRow
	{
		public override PresentingRowType presentingRowType { get; set;}

		public override string id { get; }
		public override string name { get; }
		public override string article { get; }

		public ElementPresentingDataRow(String id, String article, String name, int quantity = 1, float price = 0,
										int multiplier = 1, float discount = 0, String usersNotes = "")
		 
		{
			this.id = id;
			this.name = name;
			this.article = article;
			this.price = price;
			this.discount = discount;
			this.quantity = quantity;
			this.multiplier = multiplier;
			this.usersNotes = usersNotes;
			this.presentingRowType = PresentingRowType.element;
		}

	}
}
