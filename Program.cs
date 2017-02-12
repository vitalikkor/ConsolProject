using System;
using System.Collections.Generic;

namespace ConsolProject
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			List<SearchQuery> searchArray = new List<SearchQuery>();

			SearchQuery newSearch = new SearchQuery("query");
			searchArray.Add(newSearch);
			List<IViewPresentingDataRow> dataRows = ServiceLocator.sharedInstance.getService<IDataProvider>().getElementsDataTable(searchArray);
			//BackPanel bp = new BackPanel(family: BackPanelsFamily.ordinal, type: BackPanelType.perforation, size: new SizeLWH{L = 10, W = 10, H = 10 });

			List<BackPanel> BPL = BackPanel.getBackPanelsSet(family: BackPanelsFamily.ordinal, 
			                                                 type: BackPanelType.perforation, 
			                                                 size: new SizeLWH { L = 1000, W = 500, H = 2235 }, 
			                                                 color: new ColorRall());
			
			Console.WriteLine(dataRows[0].getArticle() + " " + dataRows[0].getName());                                                
		}
	}
}
