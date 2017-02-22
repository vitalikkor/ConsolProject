using System;
using System.Collections.Generic;

namespace ConsolProject
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			Rack oneSideRack = new OneSideRack(BackPanelType.plain, BackPanelsFamily.ordinal, new SizeLWH() { L = 1000, W = 500, H = 2235 }, new ColorRall(3000, ColorShader.mat));
			oneSideRack.multiplier = 10;
			List<IViewPresentingDataRow> rows = oneSideRack.generateViewPresentingDataRow();
			foreach (IViewPresentingDataRow row in rows)
			{
				Console.WriteLine(row.article + " " + row.name + " " + row.quantity + "\n");

			}

		}
	}
}
