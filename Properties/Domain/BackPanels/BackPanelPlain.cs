using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsolProject
{
	public class BackPanelPlain: BackPanel
	{
		//BackPanel properties
		public override BackPanelsFamily family { get; } = BackPanelsFamily.ordinal;
		public override BackPanelType type { get; } = BackPanelType.plain;

		//ElementNomenclature properties
		override protected String rootAbriviation
		{
			get { return "KL ST"; }
		}

		public override SizeLWH size { get; }

		protected override Material selfMaterial { get; }

		public BackPanelPlain(SizeLWH panelSize, ColorRall color)
		{
			this.color = color;
			this.size = panelSize;
		}

		public override List<SearchQuery> searchQuerys
		{
			get
			{
				String prefix = "ORDINAL";
				SearchQuery searchQuery = new SearchQuery(quryString: this.rootAbriviation + prefix, color: this.color);
				return new List<SearchQuery>() { searchQuery };
			}
		}

		public static List<BackPanelPlain> getBackPanelsSet(SizeLWH size, ColorRall color)
		{

			List<BackPanelPlain> listOfBackPanels = new List<BackPanelPlain>() { };
			List<int> setOfHeights = BackPanelPlain.getSetOfHeights(H: size.H);
			foreach (int h in setOfHeights)
			{
				SizeLWH panelSize = new SizeLWH { H = h, L = size.L, W = size.W };
				BackPanelPlain backPanel = new BackPanelPlain(panelSize, color);
				listOfBackPanels.Add(backPanel);

			}
			return listOfBackPanels;
		}

		public static List<int> permissibleHeights()
		{
			return new List<int> { 150, 300, 450 };
		}

		public static List<int> getSetOfHeights(int H)
		{
			List<int> sortedHeigts = BackPanelPlain.permissibleHeights().OrderByDescending((int arg) => arg).ToList();
			int iterateH = H;
			List<int> setOfHeights = new List<int>();
			foreach (int h in sortedHeigts)
			{
				if (iterateH >= h)
				{
					do
					{
						iterateH -= h;
						setOfHeights.Add(h);

					} while (iterateH >= h);
				}
			}
			return setOfHeights;
		}

		protected override List<ElementNomenclature> getElementsSatelits()
		{
			//this should be the list of all elements - satelits for each case of panel type
			return new List<ElementNomenclature>() { };
		}

		public override void onChangeColor(ColorRall newColor)
		{
			base.onChangeColor(newColor);

		}

		public override List<IViewPresentingDataRow> generateViewPresentingRow()
		{
			return ServiceLocator.sharedInstance.getService<IDataProvider>().getElementsTableView(this.searchQuerys);
		}
	}
}
