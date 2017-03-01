using System;
using System.Collections.Generic;

namespace ConsolProject
{
	public class OneSideRackBuilder: IRackBuilder
	{
		Rack rawRack = new Rack();
		RackConfigurator configurator;

		public OneSideRackBuilder(RackConfigurator configurator)
		{
			this.configurator = configurator;
		}

		public override void setSize()
		{
			rawRack.size = configurator.rack.size;
		}

		public override void setMultiplier()
		{
			rawRack.multiplier = configurator.rack.multiplier;
		}

		public override void generateBackPanels()
		{ 
			List<BackPanel> lbp;
			switch (configurator.backPanel.type)
			{
				case BackPanelType.plain:
					lbp = BackPanelPlain.getBackPanelsSet(rawRack.size, configurator.backPanel.color);
					break;
				default:
					lbp = BackPanelPlain.getBackPanelsSet(rawRack.size, configurator.backPanel.color);
					break;
			}
			rawRack.backPanels = lbp;
		}

		public override void generateFrontLegs()
		{
			
		}

		public override void generateBackLegs()
		{
		}

		public override void generateShelves()
		{
		}

		public override Rack getRack()
		{
			return rawRack;
		}

		public override void generateQueriesList()
		{
			this.rawRack.generateTotalQueriesList();
		}

		public override void generateElementsId()
		{
			ServiceLocator.sharedInstance.getService<IDataProvider>().setupElementsId(this.rawRack.generateTotalQueriesList());
		}

	}
}
