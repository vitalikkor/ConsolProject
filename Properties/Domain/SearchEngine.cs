using System;
namespace ConsolProject
{
	public class SearchEngine
	{

		public readonly SearchQuery searchQuery;

		public SearchEngine(SearchQuery searchQuery)
		{
			this.searchQuery = searchQuery;
		}


		public ElementDataTable getDataTableElement()
		{
			
			return new ElementDataTable(id: "123", paentElementId: null, article: "1212-134-23", name: "elementname");
		}


	}

}
