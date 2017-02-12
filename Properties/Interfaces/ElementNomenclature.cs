using System;
using System.Collections.Generic;

namespace ConsolProject
{
	public abstract class ElementNomenclature
	{
	    String rootAbriviation = "Root";

		private ColorRall color;

		public abstract SizeLWH getSize();

		public abstract List<SearchQuery> getSearchQuery();

		public abstract Material getSelfMaterial();



	}
}
