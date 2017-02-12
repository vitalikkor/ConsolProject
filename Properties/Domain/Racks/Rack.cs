using System;
using System.Collections.Generic;

namespace ConsolProject
{
	public class Rack
	{
		public Rack()
		{
		}

		//interface
		public List<IViewPresentingDataRow> composePresentingInvoiceElementsList()
		{
			//this should be a list of all elements
			return new List<IViewPresentingDataRow>() { };
		}

	}
}
