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

			SearchQuery newSearch = new SearchQuery() { 
				quryString = "query", 
				searchType = PreferedSearchType.byArticle,
				color = new ColorRall(111, ColorShader.mat) 
			};
			searchArray.Add(newSearch);
			List<IViewPresentingDataRow> dataRows = ServiceLocator.sharedInstance.getService<IDataProvider>().getElementsDataTable(searchArray);

			Console.WriteLine(dataRows[0].getArticle() + " " + dataRows[0].getName());                                                
		}
	}
}
