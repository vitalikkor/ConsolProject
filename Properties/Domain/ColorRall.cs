using System;

namespace ConsolProject
{
	public class ColorRall
	{
		public readonly int rallCode;
		public readonly ColorShader colorShader;

		public ColorRall(int code, ColorShader shader)
		{
			this.colorShader = shader;
			this.rallCode = code;
		}

		public String getColorAsString()
		{
			return this.rallCode.ToString() + colorShader.getDescription<ColorShader>();
		}
	}
}
