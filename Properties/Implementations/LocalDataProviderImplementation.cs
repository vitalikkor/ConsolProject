using System;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using Mono.Data.Sqlite;
using System.Collections.Generic;

namespace ConsolProject
{
	public class LocalDataProviderImplementation: IDataProvider
	{
		public LocalDataProviderImplementation(){
		}

		void IDataProvider.setupElementsId(List<SearchQuery> queries)
		{
			const string connectionString = "URI=file:/Users/vkorobitsyn/Documents/Projects/C#projects/ConsolProject/ConsolProject/mainDataBase.db";
			IDbConnection dbcon = new SqliteConnection(connectionString);
			dbcon.Open();
			IDbCommand dbcmd = dbcon.CreateCommand();

			string sql = "SELECT Element_Id, LocalizedName  FROM NamesTranslation WHERE Language_Id = 0 AND LocalizedName LIKE '%" + queries[0].quryString + "%'";
			dbcmd.CommandText = sql;
			IDataReader reader = dbcmd.ExecuteReader();
			while (reader.Read())
			{
				string name1 = reader.GetString(0);
				string name2 = reader.GetString(1);
				//int name1 = reader.GetInt32(0);
				//string name2 = reader.GetString(1);
				//int name3 = reader.GetInt32(2);
				//string name4 = reader.GetString(3);
				//string name5 = reader.GetString(4);
				//Console.WriteLine("Name: {0} {1} {2} {3} {4}", name1, name2, name3, name4, name5);
				Console.WriteLine(name1 + " " + name2);
			}
			// clean up
			reader.Dispose();
			dbcmd.Dispose();
			dbcon.Close();

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
