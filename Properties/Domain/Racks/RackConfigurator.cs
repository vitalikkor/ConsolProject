using System;

namespace ConfigurationRack
{
	public class Rack
	{
		public int multiplier = 1;
		public ConsolProject.ColorRall color = new ConsolProject.ColorRall();
		public ConsolProject.SizeLWH size = ConsolProject.SizeLWH.L1000_W500_H2235;
		public Rack() { }
	}
	public class BackPanel
	{
		public ConsolProject.ColorRall color = new ConsolProject.ColorRall();
		public ConsolProject.BackPanelType type = ConsolProject.BackPanelType.plain;
		public ConsolProject.BackPanelsFamily family = ConsolProject.BackPanelsFamily.ordinal;
		public ConsolProject.SizeLWH size = ConsolProject.SizeLWH.L1000_W500_H2235;

		public BackPanel() { }
		public BackPanel(ConsolProject.ColorRall color,ConsolProject.BackPanelType type, ConsolProject.BackPanelsFamily family,
		                ConsolProject.SizeLWH size) 
		{
			this.color = color;
			this.family = family;
			this.size = size;
			this.type = type;
		}
	}
}


namespace ConsolProject
{


	public class RackConfigurator
	{
		public ConfigurationRack.Rack rack = new ConfigurationRack.Rack();
		public ConfigurationRack.BackPanel backPanel = new ConfigurationRack.BackPanel();

		public RackConfigurator()
		{
		}

	}
}
