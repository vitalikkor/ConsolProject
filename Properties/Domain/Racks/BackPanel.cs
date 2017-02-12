using System;
using System.Collections.Generic;

namespace ConsolProject
{
	public class BackPanel: ElementNomenclature
	{
		protected String rootAbriviation = "KL ST";

		private BackPanelsFamily family;
		private BackPanelType type;
		private SizeLWH size;
		private ColorRall color;
		private Material selfMaterial;

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
				case BackPanelType.plain:
					selfMaterial = Material.metall;
					break;
				case BackPanelType.wiredType1: 
				case BackPanelType.wiredType2:
					selfMaterial = Material.wireMetall;
					break;
			}
		}

		public BackPanel(BackPanelsFamily family, BackPanelType type, SizeLWH size):
		this(family, type, size, new ColorRall())
		{ 
		}

		public override List<SearchQuery> getSearchQuery()
		{
			String prefix = "";
			switch (this.family){
				case BackPanelsFamily.middle:
					prefix = "MD";
					break;
				case BackPanelsFamily.ordinal:
					prefix = "ORD";
					break;
			}
			SearchQuery searchQuery = new SearchQuery(quryString: rootAbriviation + prefix, color: color);
			return new List<SearchQuery>() {searchQuery};
		}

		public override SizeLWH getSize()
		{
			return this.size;
		}

		public override Material getSelfMaterial()
		{
			return selfMaterial;
		}

		public static List<BackPanel> getBackPanelsSet(BackPanelsFamily family, BackPanelType type, SizeLWH size, ColorRall color)
		{
			List<int> setOfHeights = getSetOfHeights(family: family, type: type, size: size);
			List<BackPanel> listOfBackPanels = new List<BackPanel>() { };
			foreach (int h in setOfHeights)
			{
				SizeLWH panelSize = new SizeLWH { H = h, L = size.L, W = size.W };
				listOfBackPanels.Add(new BackPanel(family, type, panelSize, color));

			}
			return listOfBackPanels;
		}

		protected static List<int> getSetOfHeights(BackPanelsFamily family, BackPanelType type, SizeLWH size)
		{
			
			return new List<int>() { 300, 300, 300, 450 };
		}


	}
}
