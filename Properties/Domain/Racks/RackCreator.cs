using System;
namespace ConsolProject
{
	public class RackCreator
	{
		private readonly IRackBuilder rackBuilder;

		public RackCreator(IRackBuilder rackBuilder)
		{
			this.rackBuilder = rackBuilder;
		}

		public void creatRack()
		{
			rackBuilder.generateRack();
		}


		public Rack getRack()
		{
			return rackBuilder.getRack();
		}
	}
}
