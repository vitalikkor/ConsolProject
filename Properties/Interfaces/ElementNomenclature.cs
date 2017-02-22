using System;
using System.Collections.Generic;

namespace ConsolProject
{
	public abstract class ElementNomenclature
	{

		//main method which search throght database element by search query
		abstract public List<IViewPresentingDataRow> generateViewPresentingRow();

		// abriviation is used when search element in database
		abstract protected String rootAbriviation { get; }

		// list of elements included this. Usual this is only one item
		public abstract List<SearchQuery> searchQuerys { get; }

		//color
		public virtual ColorRall color 
		{ 
			get { return color;} 
			set{
				onChangeColor(color);
			}
		}

		//Size which using in composing search query
		public abstract SizeLWH size { get; }

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

		public virtual void onChangeColor(ColorRall newColor)
		{
			this.color = newColor;
		}
	}
}
