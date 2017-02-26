using System;
using System.Collections.Generic;

namespace ConsolProject
{
	public class ElementSatelit: ElementNomenclature
	{
		private SearchQuery sQuery;
		private Material material;
		public ElementSatelit(SearchQuery query, SizeLWH size, Material material)
		{
			this.sQuery = query;
			color = query.color;
			this.size = size;
			this.material = material;
		}

		public ElementSatelit(SearchQuery query, SizeLWH size)
		{
			this.sQuery = query;
			color = query.color;
			this.size = size;
			this.material = Material.metall;
		}

		public ElementSatelit(SearchQuery query)
		{
			this.sQuery = query;
			color = query.color;
			this.size = SizeLWH.Zerro;
			this.material = Material.metall;
		}

		public override List<IViewPresentingDataRow> generateViewPresentingRow(int multipleir)
		{
			Console.WriteLine("**************This func can take a lot of time!!!!!!!!");
			return ServiceLocator.sharedInstance.getService<IDataProvider>().getElementsTableView(this.getSearchQuerys());
		}

		override protected String rootAbriviation
		{
			get { return ""; }
		}


		// list of elements included this. Usual this is only one item
		public override List<SearchQuery> getSearchQuerys()
		{
			return new List<SearchQuery>(){ sQuery };
		}

		public override void onChangeColor(ColorRall newColor)
		{
		}

		protected override Material selfMaterial
		{
			get
			{
				return this.material;
			}
		}

	}
}
