using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsolProject
{
	public class BackPanelPlain : BackPanel
	{
		//BackPanel properties
		public override BackPanelsFamily family { get; } = BackPanelsFamily.ordinal;
		public override BackPanelType type { get; } = BackPanelType.plain;

		//ElementNomenclature properties
		override protected String rootAbriviation
		{
			get { return "KL ST"; }
		}
		public override ColorRall color { get; set; }

		protected override Material selfMaterial { get; } = Material.metall;

		public override int selfQuantity { get; set;}

		public BackPanelPlain(SizeLWH panelSize, ColorRall color)
		{
			base.size = panelSize;
			base.color = color;
			this.color = color;
		}

		public override List<SearchQuery> searchQuerys(int multiplier)
		{
				String prefix = "ORDINAL";
				SearchQuery searchQuery = new SearchQuery(quryString: this.rootAbriviation + " " + 
				                                          size.H.ToString() + " " + size.L.ToString() + " " + prefix + " ", color: this.color);
				searchQuery.quantity = this.selfQuantity*multiplier;
				return new List<SearchQuery>() { searchQuery };
		}

		public static List<BackPanel> getBackPanelsSet(SizeLWH size, ColorRall color)
		{
			List<BackPanel> listOfBackPanels = new List<BackPanel>() { };
			Dictionary<int, int> setOfHeights = BackPanelPlain.getSetOfHeights(H: size.H);
			foreach (KeyValuePair<int, int> item in setOfHeights)
			{
				SizeLWH panelSize = new SizeLWH { H = item.Key, L = size.L, W = size.W };
				BackPanelPlain backPanel = new BackPanelPlain(panelSize, color);
				backPanel.selfQuantity = item.Value;
				listOfBackPanels.Add(backPanel);

			}
			return listOfBackPanels;
		}

		public static List<int> permissibleHeights()
		{
			return new List<int> { 150, 300, 450 };
		}

		public static Dictionary<int , int> getSetOfHeights(int H)
		{
			List<int> sortedHeigts = BackPanelPlain.permissibleHeights().OrderByDescending((int arg) => arg).ToList();
			int iterateH = H;
			Dictionary<int, int>  setOfHeights = new Dictionary<int, int> ();
			foreach (int h in sortedHeigts)
			{
				if (iterateH >= h)
				{
					int i = 0;
					do
					{
						iterateH -= h;
						i++;
					} while (iterateH >= h);
					if (i > 0){
						setOfHeights.Add(h, i);
					}
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
			

		}

		public override List<IViewPresentingDataRow> generateViewPresentingRow(int multipleir)
		{
			return ServiceLocator.sharedInstance.getService<IDataProvider>().getElementsTableView(this.searchQuerys(multipleir));
		}
	}
}
