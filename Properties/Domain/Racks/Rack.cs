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

		public List<IViewPresentingDataRow> generateViewPresentingDataRow()
		{

			return ServiceLocator.sharedInstance.getService<IDataProvider>().getElementsTableView(generateTotalElementsList());
		}

		public List<SearchQuery> generateTotalQueriesList()
		{
			List<ElementNomenclature> totalElementsList = generateTotalElementsList();

			List<SearchQuery> sqList = new List<SearchQuery>();
			totalElementsList.ForEach((ElementNomenclature element) =>
			{
				sqList.Add(element.getSelfSearchQuery());
			});

			return sqList;
		}

		public List<ElementNomenclature> generateTotalElementsList()
		{
			List<ElementNomenclature> totalElementsList = new List<ElementNomenclature>();
			totalElementsList.AddRange(this.backPanels);
			totalElementsList.AddRange(this.frontLegs);
			totalElementsList.AddRange(this.shelves);
			//getting subelements and satelits
			List<ElementNomenclature> additionalList = new List<ElementNomenclature>();
			//recursive func
			Func<ElementNomenclature, List < ElementNomenclature >> getSubelements = delegate (ElementNomenclature element)
			   {
					return element.getSubElements();
			   };
			//loop and invoke recursive func
			totalElementsList.ForEach((ElementNomenclature element) =>
			{
				additionalList.AddRange(element.getSatelitsElements());

				getSubelements(element).ForEach((ElementNomenclature subelement) =>
				{
					additionalList.AddRange(getSubelements(subelement));
				});

			});
			totalElementsList.AddRange(additionalList);
			return totalElementsList;
		}


	}
}
