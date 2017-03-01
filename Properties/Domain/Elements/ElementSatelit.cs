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
			query.callbackId = (string id) => this.elementId = id;
		}

		public ElementSatelit(SearchQuery query, SizeLWH size)
		{
			this.sQuery = query;
			color = query.color;
			this.size = size;
			this.material = Material.metall;
			query.callbackId = (string id) => this.elementId = id;
		}

		public ElementSatelit(SearchQuery query)
		{
			this.sQuery = query;
			color = query.color;
			this.size = SizeLWH.Zerro;
			this.material = Material.metall;
			query.callbackId = (string id) => this.elementId = id;
		}

		public override List<IViewPresentingDataRow> generateViewPresentingRow(int multipleir)
		{
			Console.WriteLine("**************This func can take a lot of time!!!!!!!!");
			List<SearchQuery> queriesList = new List<SearchQuery>();
			queriesList.Add(this.getSelfSearchQuery());
			return ServiceLocator.sharedInstance.getService<IDataProvider>().getElementsTableView(queriesList);
		}

		override protected String rootAbriviation
		{
			get { return ""; }
		}


		// list of elements included this. Usual this is only one item
		public override SearchQuery getSelfSearchQuery()
		{
			return this.sQuery;
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
