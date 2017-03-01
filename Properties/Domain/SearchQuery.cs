using System;
namespace ConsolProject
{
	public class SearchQuery
	{
		
		public readonly string quryString;
		public readonly PreferedSearchType searchType;
		public readonly ColorRall color;
		public Action<string> callbackId = delegate {};

		public SearchQuery(string quryString, ColorRall color, PreferedSearchType searchType = PreferedSearchType.byName)
		{
			this.quryString = quryString;
			this.searchType = searchType;
			this.color = color;

		}

		public SearchQuery(string quryString, PreferedSearchType searchType = PreferedSearchType.byName)
		{
			this.quryString = quryString;
			this.searchType = searchType;
			color = new ColorRall(9001, ColorShader.semiMat);

		}

	}
}
