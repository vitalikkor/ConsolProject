using System;
using System.Collections.Generic;

namespace ConsolProject
{
	public abstract class BackPanel: ElementNomenclature
	{

		public abstract BackPanelsFamily family { get; }
		public abstract BackPanelType type { get; }

	}
}
