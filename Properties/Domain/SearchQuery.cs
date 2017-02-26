using System;
namespace ConsolProject
{
	public class SearchQuery
	{
		public float quantity = 1;
		public readonly string quryString;
		public readonly PreferedSearchType searchType;
		public readonly ColorRall color;


		public SearchQuery(string quryString, ColorRall color, PreferedSearchType searchType = PreferedSearchType.byName, float quantity = 1)
		{
			this.quryString = quryString;
			this.searchType = searchType;
			this.color = color;
			this.quantity = quantity;
		}

		public SearchQuery(string quryString , PreferedSearchType searchType = PreferedSearchType.byName, float quantity = 1)
		{
			this.quryString = quryString;
			this.searchType = searchType;
			this.color = new ColorRall(code: 9001, shader: ColorShader.semiMat);
			this.quantity = quantity;
		}

	}
}
