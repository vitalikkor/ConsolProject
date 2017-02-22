using System;
using System.Collections.Generic;

namespace ConsolProject
{
	public abstract class ElementNomenclature
	{

		//main method which search throght database element by search query
		abstract public List<IViewPresentingDataRow> generateViewPresentingRow(int multipleir);

		// abriviation is used when search element in database
		abstract protected String rootAbriviation { get; }

		// list of elements included this. Usual this is only one item
		public abstract List<SearchQuery> searchQuerys(int multiplier);

		//color
		public virtual ColorRall color { get; set;}
		public abstract void onChangeColor(ColorRall newColor);

		public virtual int selfQuantity { get; set; } = 1;

		//Size which using in composing search query
		public virtual SizeLWH size { get; set; }

		//real material of element it can be unknown
		protected abstract Material selfMaterial { get; }

		//subelements of this elements
		public virtual List<ElementNomenclature> elementsSatelits
		{
			get
			{
				if (elementsSatelits.Count == 0)
				{
					return getElementsSatelits();
				}
				else
				{
					return elementsSatelits;
				}
			}
		}

		protected virtual List<ElementNomenclature> getElementsSatelits()
		{
			return new List<ElementNomenclature>() { };
		}

	}
	
}
