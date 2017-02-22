using System;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace ConsolProject
{
	public class LocalDataProviderImplementation: IDataProvider
	{
		public LocalDataProviderImplementation(){
		}


		List<IViewPresentingDataRow> IDataProvider.getElementsTableView(List<SearchQuery> queries)
		{
			List<IViewPresentingDataRow> array = new List<IViewPresentingDataRow>();
			//String connectionString =
			//	"Integrated Security=SSPI;Persist Security Info=False;" +
			//	"Initial Catalog=Northwind;Data Source=localhost";

			//SqlDataAdapter dataAdapter = new SqlDataAdapter(this.composeSQLCommand(queries), connectionString);

			IViewPresentingDataRow element = new ElementPresentingDataRow("uniq1", "1222-111-22", 
			                    queries[0].quryString + " wewe ererere eferer " + queries[0].color.getColorAsString(), quantity: queries[0].quantity);
			IViewPresentingDataRow element2 = new ElementPresentingDataRow("uniq2", "9999-181-32", 
			                    queries[0].quryString + " asawewe erasdadsferer" + queries[0].color.getColorAsString(), quantity: queries[0].quantity);

			array.AddRange(new IViewPresentingDataRow[]{ element, element2 });

			return array;				
		}

		private String composeSQLCommand(SearchQuery[] queries)
		{
			String command = "";
			foreach (SearchQuery query in queries){
				
				switch (query.searchType)
				{
					case PreferedSearchType.byName:
						command += "";
						break;
					case PreferedSearchType.byArticle:
						command += "";
						break;
					case PreferedSearchType.none:
						command += "";
						break;
				}
			}
			return command;
		}
	}
}
