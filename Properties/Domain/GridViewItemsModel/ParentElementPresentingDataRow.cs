using System;
namespace ConsolProject
{
	public class ParentElementPresentingDataRow: ElementPresentingDataRow
	{

		public ParentElementPresentingDataRow(String id, String article, String name, int quantity = 1, float price = 0,
										int multiplier = 1, float discount = 0, String description = ""):
		base(id, article, name, quantity, price, multiplier, discount, description)
		
		{
			this.presentingRowType = PresentingRowType.elementParent;
		}

	}
}
