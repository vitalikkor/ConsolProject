using System;
namespace ConsolProject
{
	public abstract class IRackBuilder
	{
		public abstract void setSize();
		public abstract void setMultiplier();
		public abstract void generateBackPanels();
		public abstract void generateFrontLegs();
		public abstract void generateBackLegs();
		public abstract void generateShelves();
		public abstract void generateQueriesList();
		public abstract void generateElementsId();

		public virtual void generateRack()
		{
			setSize();
			setMultiplier();
			generateBackPanels();
			generateFrontLegs();
			generateBackLegs();
			generateShelves();

			generateQueriesList();

			generateElementsId();
		}

		public abstract Rack getRack();
	}
}
