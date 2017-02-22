using System;
using System.Collections.Generic;

namespace ConsolProject
{
	public abstract class Rack
	{
		public abstract List<BackPanel> generateBackPanels(SizeLWH size, ColorRall color);
		public abstract List<string> generateBackLeg();
		public abstract List<string> generateFrontLeg();
	}
}
