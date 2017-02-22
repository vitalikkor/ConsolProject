using System;
using System.Collections.Generic;

namespace ConsolProject
{
	public class OneSideRack: Rack
	{
		public BackPanelType backPanelType;
		public BackPanelsFamily backPanelFamily;
		public SizeLWH size;
		public ColorRall color;

		public OneSideRack(BackPanelType backPanelType, BackPanelsFamily backPanelFamily, SizeLWH size, ColorRall color)
		{
			this.backPanelFamily = backPanelFamily;
			this.backPanelType = backPanelType;
			this.color = color;
			this.size = size;
		}

		public override List<BackPanel> generateBackPanels()
		{
			List<BackPanel> lbp;
			switch (backPanelType)
			{
				case BackPanelType.plain:
					lbp = BackPanelPlain.getBackPanelsSet(this.size, this.color);
					break;
				default:
					lbp = BackPanelPlain.getBackPanelsSet(this.size, this.color);
					break;
			}
			return lbp;
		}

		public override List<string> generateBackLeg()
		{
			return new List<string>();
		}

		public override List<string> generateFrontLeg()
		{
			return new List<string>();
		}
	}
}
