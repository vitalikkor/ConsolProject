using System;
using System.Collections.Generic;

namespace ConsolProject
{
	public class OneSideRack: Rack
	{
		public OneSideRack()
		{
		}

		public override List<BackPanel> generateBackPanels(SizeLWH size, ColorRall color)
		{
			BackPanel bp = new BackPanelPlain(size, color);
			return new List<BackPanel>(){ bp};
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
