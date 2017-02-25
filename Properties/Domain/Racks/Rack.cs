using System;
using System.Collections.Generic;

namespace ConsolProject
{
	public class Rack
	{
		public int multiplier { get; set; } = 1;
		public SizeLWH size;
		public List<BackPanel> backPanels { get; set;}
		public List<string> backLegs { get; set; }
		public List<string> frontLegs { get; set; }
		public List<string> shelves { get; set;}


		public List<IViewPresentingDataRow> generateViewPresentingDataRow()
		{
			List<IViewPresentingDataRow> rows = new List<IViewPresentingDataRow>();
			foreach (BackPanel bp in backPanels)
			{
				rows.AddRange(bp.generateViewPresentingRow(multiplier));
			}

			//foreach (string bl in backLegs)
			//{
			//	//rows.AddRange(bl.generateViewPresentingRow());
			//}

			//foreach (string bl in frontLegs)
			//{
			//	//rows.AddRange(bl.generateViewPresentingRow());
			//}

			//foreach (string bl in shelves)
			//{
			//	//rows.AddRange(bl.generateViewPresentingRow());
			//}
			return rows;
		}
	}
}
