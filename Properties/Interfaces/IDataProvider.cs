using System;
using System.Data;
using System.Xml;
using System.Collections.Generic;

namespace ConsolProject
{
	public interface IDataProvider
	{
		List<IViewPresentingDataRow> getElementsDataTable(List<SearchQuery> query);
	}
}
