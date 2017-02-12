using System;
namespace ConsolProject
{
	public class SearchQuery
	{
		public SearchQuery(string quryString, ColorRall color, PreferedSearchType searchType = PreferedSearchType.byName)
		{
			this.quryString = quryString;
			this.searchType = searchType;
			this.color = color;
		}

		public SearchQuery(string quryString , PreferedSearchType searchType = PreferedSearchType.byName)
		{
			this.quryString = quryString;
			this.searchType = searchType;
			this.color = new ColorRall(code: 9001, shader: ColorShader.semiMat);
		}
		public readonly string quryString;
		public readonly PreferedSearchType searchType;
		public readonly ColorRall color;
	}
}
