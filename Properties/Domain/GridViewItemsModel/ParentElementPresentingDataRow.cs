﻿using System;
namespace ConsolProject
{
	public class ParentElementPresentingDataRow: ElementPresentingDataRow
	{

		public ParentElementPresentingDataRow(String article, String name, int quantity = 1, float price = 0,
										int multiplier = 1, float discount = 0, String description = ""):
		base(article, name, quantity, price, multiplier, discount, description)
		
		{
			this.presentingStile = PresentingRowType.elementParent;
		}

	}
}
