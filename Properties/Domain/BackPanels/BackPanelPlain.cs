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

		protected override Material selfMaterial { get; } = Material.metall;

		public BackPanelPlain(SizeLWH panelSize, ColorRall color)
		{
			base.size = panelSize;
			base.color = color;
		}

		public override List<SearchQuery> getSearchQuerys()
		{
			List<SearchQuery> searchQs = getSatelitsSearchQuerys();
			String prefix = "ORDINAL";
			//Panel
			SearchQuery panelSearchQuery = new SearchQuery(quryString: this.rootAbriviation + " " + 
				                                          size.H.ToString() + " " + size.L.ToString() + " " + prefix + " ", color: this.color);
				panelSearchQuery.quantity = this.selfQuantity;
 
			searchQs.Add(panelSearchQuery);

			return searchQs;
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
			SearchQuery fixatorSearchQuery = new SearchQuery(quryString: "KN FK Back Panel's fixator ", color: new ColorRall(Galvanic.zinc), quantity: 1);

			ElementSatelit fixator = new ElementSatelit(fixatorSearchQuery);
			return new List<ElementNomenclature>() { fixator };
		}

		public override void onChangeColor(ColorRall newColor)
		{
			

		}

		public override List<IViewPresentingDataRow> generateViewPresentingRow(int multipleir)
		{
			Console.WriteLine("**************This func can take a lot of time!!!!!!!!");
			return ServiceLocator.sharedInstance.getService<IDataProvider>().getElementsTableView(this.getSearchQuerys());
		}
	}
}
