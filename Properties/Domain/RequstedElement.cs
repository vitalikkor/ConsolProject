using System;
namespace ConsolProject
{
	public class RequstedElement
	{
		
		public RequstedElement()
		{
		}

		public ElementDataTable[] getDataTableElements()
		{

			ServiceLocator.sharedInstance.getService<IDataProvider>().getElementsData("queryString");//getElementsData();
			return new ElementDataTable[3];
		}
	}
}
