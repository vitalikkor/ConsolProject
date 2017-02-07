using System;
namespace ConsolProject
{
	public class ElementDataTable: IEquatable<ElementDataTable>
	{
		public readonly string id;
		public readonly string parentElementId;
		public readonly string presentingName;
		public readonly string article;

		//public ElementDataTable[] childElements = new ElementDataTable[] { };
		
		public ElementDataTable(String id, string paentElementId, String article, String name)
		{
			this.id = id;
			this.parentElementId = paentElementId;
			this.article = article;
			this.presentingName = name;
		}

		// IEquatable implementation

		public bool Equals(ElementDataTable other)
		{
			if (other == null)
				return false;

			if ((this.id == other.id) & (this.article == other.article) & (this.presentingName == other.presentingName))
				return true;
			else
				return false;
		}

		public override bool Equals(Object obj)
		{
			if (obj == null)
				return false;

			ElementDataTable personObj = obj as ElementDataTable;
			if (personObj == null)
				return false;
			else
				return Equals(personObj);
		}

		public override int GetHashCode()
		{
			return this.id.GetHashCode();
		}

		public static bool operator ==(ElementDataTable element1, ElementDataTable element2)
		{
			if (((object)element1) == null || ((object)element2) == null)
				return Object.Equals(element1, element2);

			return element1.Equals(element2);
		}

		public static bool operator !=(ElementDataTable element1, ElementDataTable element2)
		{
			if (((object)element1) == null || ((object)element2) == null)
				return !Object.Equals(element1, element2);

			return !(element1.Equals(element2));
		}
	}
}
