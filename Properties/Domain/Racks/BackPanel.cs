using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsolProject
{
	public class BackPanel: ElementNomenclature
	{
		override protected String rootAbriviation
		{
			get { return "KL ST"; }
		}

		public override ColorRall color { get; set; }

		public override SizeLWH size { get; }

		private BackPanelsFamily family;
		private BackPanelType type;

		protected override Material selfMaterial { get;}

		public BackPanel(BackPanelsFamily family, BackPanelType type, SizeLWH size, ColorRall color)
		{
			this.color = color;
			this.size = size;
			this.type = type;
			this.family = family;
			switch (this.type)
			{
				case BackPanelType.DSPpanel:
					selfMaterial = Material.DSP;
					break;
				case BackPanelType.MDFpanel:
					selfMaterial = Material.MDF;
					break;
				case BackPanelType.perforation:
					selfMaterial = Material.metall;
					break;
				case BackPanelType.plain:
					selfMaterial = Material.metall;
					break;
				case BackPanelType.wiredType1: 
					selfMaterial = Material.wireMetall;
					break;
				case BackPanelType.wiredType2:
					selfMaterial = Material.wireMetall;
					break;
			}
		}

		public BackPanel(BackPanelsFamily family, BackPanelType type, SizeLWH size):
		this(family, type, size, new ColorRall())
		{ }

		public override List<SearchQuery> searchQuerys
		{ get
			{
				String prefix = "";
				switch (this.family)
				{
					case BackPanelsFamily.middle:
						prefix = "MD";
						break;
					case BackPanelsFamily.ordinal:
						prefix = "ORD";
						break;
				}
				SearchQuery searchQuery = new SearchQuery(quryString: this.rootAbriviation + prefix, color: this.color);
				return new List<SearchQuery>() { searchQuery };
			}
		}


		public static List<BackPanel> getBackPanelsSet(BackPanelsFamily family, BackPanelType type, SizeLWH size, ColorRall color)
		{
			
			List<BackPanel> listOfBackPanels = new List<BackPanel>() { };
			List<int> setOfHeights =BackPanel.getSetOfHeights(family: family, type: type, H: size.H);
			foreach (int h in setOfHeights)
			{
				SizeLWH panelSize = new SizeLWH { H = h, L = size.L, W = size.W };
				BackPanel backPanel = new BackPanel(family, type, panelSize, color);
				listOfBackPanels.Add(backPanel);

			}
			return listOfBackPanels;
		}

		private static List<int> permissibleHeights(BackPanelsFamily family, BackPanelType type)
		{
			switch (type)
			{
				case BackPanelType.DSPpanel:
				case BackPanelType.MDFpanel:
					return new List<int> {};
				case BackPanelType.perforation:
					return new List < int > { 150, 300, 450 };
				case BackPanelType.plain:
					return new  List < int > { 150, 300, 450 };
				case BackPanelType.wiredType1:
					return new  List < int >{ 300, 450, 900 };
				case BackPanelType.wiredType2:
					return new List<int> { 300, 450 };
			}
			return new List<int> { };
		}
		                                            
		public static List<int> getSetOfHeights(BackPanelsFamily family, BackPanelType type, int H)
		{
			List<int> sortedHeigts = BackPanel.permissibleHeights( family, type).OrderByDescending( (int arg) => arg).ToList();
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

		public override void changeColorTo(ColorRall newColor)
		{
			base.changeColorTo(newColor);

		}

		public override List<IViewPresentingDataRow> generateViewPresentingRow()
		{
			return ServiceLocator.sharedInstance.getService<IDataProvider>().getElementsTableView(this.searchQuerys);
		}

	}
}
