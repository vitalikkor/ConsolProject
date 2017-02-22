using System;
using System.Collections.Generic;

namespace ConsolProject
{
	public abstract class Rack
	{
		public virtual int multiplier { get; set; } = 1;
		public abstract List<BackPanel> generateBackPanels();
		public abstract List<string> generateBackLeg();
		public abstract List<string> generateFrontLeg();

		public virtual List<IViewPresentingDataRow> generateViewPresentingDataRow()
		{
			List<IViewPresentingDataRow> rows = new List<IViewPresentingDataRow>();
			foreach (BackPanel bp in generateBackPanels())
			{
				rows.AddRange(bp.generateViewPresentingRow(multiplier));
			}

			foreach (string bl in generateBackLeg())
			{
				//rows.AddRange(bl.generateViewPresentingRow());
			}

			foreach (string bl in generateBackLeg())
			{
				//rows.AddRange(bl.generateViewPresentingRow());
			}
			return rows;
		}
	}
}
