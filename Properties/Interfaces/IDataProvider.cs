using System;
using System.Data;
using System.Xml;
using System.Collections.Generic;

namespace ConsolProject
{
	public interface IDataProvider
	{
		void setupElementsId(List<SearchQuery> queries);
		                          
		List<IViewPresentingDataRow> getElementsTableView(List<SearchQuery> query);

		List<IViewPresentingDataRow> getElementsTableView(List<ElementNomenclature> elementsList);
	}
}
