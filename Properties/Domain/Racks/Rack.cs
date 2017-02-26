using System;
using System.Collections.Generic;

namespace ConsolProject
{
	public class Rack
	{
		public int multiplier { get; set; } = 1;
		public SizeLWH size;
		public List<BackPanel> backPanels { get; set; } = new List<BackPanel>();
		public List<ElementNomenclature> backLegs { get; set; } = new List<ElementNomenclature>();
		public List<ElementNomenclature> frontLegs { get; set; } = new List<ElementNomenclature>();
		public List<ElementNomenclature> shelves { get; set; } = new List<ElementNomenclature>();
		public List<SearchQuery> totalQueriesList { get; set; } = new List<SearchQuery>();

		public List<IViewPresentingDataRow> generateViewPresentingDataRow()
		{

			return ServiceLocator.sharedInstance.getService<IDataProvider>().getElementsTableView(totalQueriesList);
		}

		public void generateTotalQueriesList()
		{
			List<ElementNomenclature> totalElementsList = new List<ElementNomenclature>();
			totalElementsList.AddRange(this.backPanels);
			totalElementsList.AddRange(this.frontLegs);
			totalElementsList.AddRange(this.shelves);

			List<SearchQuery> sqList = new List<SearchQuery>();
			totalElementsList.ForEach((ElementNomenclature element) => sqList.AddRange(element.getSearchQuerys()));

			totalQueriesList = sqList;
		}
	}
}
