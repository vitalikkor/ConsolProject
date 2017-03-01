using System.Collections.Generic;

namespace ConsolProject
{
	public abstract class ElementNomenclature
	{
		//uniq string which we getting after first riquest to database
		virtual protected string elementId { get; set; } = "";

		//if current element is in list of subElements of enother element
		virtual protected string parentElementId { get; set; } = "";

		//color
		public virtual ColorRall color { get; set; } = new ColorRall();
		public abstract void onChangeColor(ColorRall newColor);

		public virtual float selfQuantity { get; set; } = 1;

		//Size which using in composing search query
		public virtual SizeLWH size { get; set; } = SizeLWH.Zerro;

		//real material of element it can be unknown
		protected abstract Material selfMaterial { get; }

		public virtual string getElementId()
		{
			return elementId;
		}

		public virtual string getParentElementId()
		{
			return parentElementId;
		}
		//main method which search throght database element by search query
		abstract public List<IViewPresentingDataRow> generateViewPresentingRow(int multipleir);

		// abriviation is used when search element in database
		abstract protected string rootAbriviation { get; }

		// list of elements included this. Usual this is only one item
		public abstract SearchQuery getSelfSearchQuery();

		public virtual List<SearchQuery> getSatelitsSearchQuerys()
		{
			List<SearchQuery> sqList = new List<SearchQuery>();
			getSatelitsElements().ForEach((ElementNomenclature element) => sqList.Add(element.getSelfSearchQuery()));
			return sqList;
		}

		public virtual List<ElementNomenclature> getSatelitsElements()
		{
			return new List<ElementNomenclature>() { };
		}

		public virtual List<ElementNomenclature> getSubElements()
		{
			return new List<ElementNomenclature>() { };
		}



	}

}
