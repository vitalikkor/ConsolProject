using System;

namespace ConsolProject
{


	public class ColorRall
	{
		public readonly int? rallCode;
		public readonly ColorShader? colorShader;
		public readonly Galvanic? galvanicType;

		public ColorRall()
		{
			this.colorShader = ColorShader.semiMat;
			this.rallCode = 9001;
		}

		public ColorRall(Galvanic galvanicType)
		{
			this.galvanicType = galvanicType;
		}

		public ColorRall(int code, ColorShader shader)
		{
			this.colorShader = shader;
			this.rallCode = code;
		}

		public static ColorRall getDefaulteColorRall()
		{
			return new ColorRall(code: 9001, shader: ColorShader.semiMat);
		}

		public String getColorAsString()
		{
			if (rallCode == null || colorShader == null)
			{
				return this.galvanicType.getDescription<Galvanic>();
			}
			else
			{
				return this.rallCode.ToString() + colorShader.getDescription<ColorShader>();
			}
		}
	}
}
