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

		void IDataProvider.setupElementsId(List<SearchQuery> queries)
		{
			int i = 0;
			foreach (SearchQuery sq in queries)
			{
				sq.callbackId.Invoke("uniq" + i.ToString()); i++;
			}

		}

		List<IViewPresentingDataRow> IDataProvider.getElementsTableView(List<SearchQuery> queries)
		{
			List<IViewPresentingDataRow> array = new List<IViewPresentingDataRow>();
			//String connectionString =
			//	"Integrated Security=SSPI;Persist Security Info=False;" +
			//	"Initial Catalog=Northwind;Data Source=localhost";

			//SqlDataAdapter dataAdapter = new SqlDataAdapter(this.composeSQLCommand(queries), connectionString);
			foreach (SearchQuery sq in queries)
			{
				IViewPresentingDataRow element = new ElementPresentingDataRow("uniq1", "1222-111-22",
								sq.quryString + " wewe ererere eferer " + sq.color.getColorAsString());
				array.Add(element);
			}
			return array;				
		}

		List<IViewPresentingDataRow> IDataProvider.getElementsTableView(List<ElementNomenclature> elementsList)
		{
			List<IViewPresentingDataRow> array = new List<IViewPresentingDataRow>();
			//String connectionString =
			//	"Integrated Security=SSPI;Persist Security Info=False;" +
			//	"Initial Catalog=Northwind;Data Source=localhost";

			//SqlDataAdapter dataAdapter = new SqlDataAdapter(this.composeSQLCommand(queries), connectionString);
			foreach (ElementNomenclature element in elementsList)
			{
				IViewPresentingDataRow elementRow = new ElementPresentingDataRow(element.getElementId(), "1222-111-22",
				                                      " wewe ererere eferer ", quantity: element.selfQuantity);
				array.Add(elementRow);
			}
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
