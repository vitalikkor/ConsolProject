using System;
using System.Collections.Generic;

namespace ConsolProject
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			RackConfigurator configurator = new RackConfigurator();
			configurator.rack.multiplier = 10;
			configurator.backPanel.color = new ColorRall(Galvanic.zinc);

			IRackBuilder oneSideRackBilder = new OneSideRackBuilder(configurator);
			RackCreator rackCreator = new RackCreator(oneSideRackBilder);
			rackCreator.creatRack();
			Rack oneSideRack = rackCreator.getRack();
			List<IViewPresentingDataRow> rows = oneSideRack.generateViewPresentingDataRow();

			foreach (IViewPresentingDataRow row in rows)
			{
				Console.WriteLine(row.getId() + " " + row.getArticle() + " " + row.getName() + " " + row.getQuantity() + "\n");

			}

		}
	}
}
