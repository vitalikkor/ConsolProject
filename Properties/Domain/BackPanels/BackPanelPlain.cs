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
			get { return "КМ СТ"; }
		}

		protected override Material selfMaterial { get; } = Material.metall;

		public BackPanelPlain(SizeLWH panelSize, ColorRall color)
		{
			base.size = panelSize;
			base.color = color;
		}

		public override SearchQuery getSelfSearchQuery()
		{
			String prefix = "";
			//Panel
			SearchQuery panelSearchQuery = new SearchQuery(quryString: this.rootAbriviation + " " + 
				                                          size.H.ToString() + " " + size.L.ToString() + " " + prefix, color: this.color);
			panelSearchQuery.callbackId = (string id) => this.elementId = id;
			return panelSearchQuery;
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


		public override void onChangeColor(ColorRall newColor)
		{
			

		}

		public override List<ElementNomenclature> getSatelitsElements()
		{
			SearchQuery fixatorSearchQuery = new SearchQuery(quryString: "KN FK Back Panel's fixator ", color: new ColorRall(Galvanic.zinc), searchType: PreferedSearchType.byName);

			ElementNomenclature satelit = new ElementSatelit(fixatorSearchQuery);

			return new List< ElementNomenclature >(){satelit};
		}

		public override List<IViewPresentingDataRow> generateViewPresentingRow(int multipleir)
		{
			Console.WriteLine("**************This func can take a lot of time!!!!!!!!");
			List<SearchQuery> listQueries = new List<SearchQuery>() { this.getSelfSearchQuery()};
			return ServiceLocator.sharedInstance.getService<IDataProvider>().getElementsTableView(listQueries);
		}
	}
}
