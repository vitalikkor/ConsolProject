using System;
using System.ComponentModel;
using System.Reflection;

public static class MyExtensions
{
	public static String getDescription<T>(this object enumerationValue) where T : struct
	{
		Type type = enumerationValue.GetType();
		if (!type.IsEnum)
		{
			throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
		}

		//Tries to find a DescriptionAttribute for a potential friendly name
		//for the enum
		MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
		if (memberInfo != null && memberInfo.Length > 0)
		{
			object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

			if (attrs != null && attrs.Length > 0)
			{
				//Pull out the description value
				return ((DescriptionAttribute)attrs[0]).Description;
			}
		}
		//If we have no description attribute, just return the ToString of the enum
		return enumerationValue.ToString();

	}
}


namespace ConsolProject
{
	public enum PreferedSearchType
	{
		byName,
		byArticle,
		none,
	}

	public enum Galvanic
	{
		[Description("zinc")]
		zinc,
		[Description("chrome")]
		chrome,
	}

	public enum ColorShader
	{
		[Description("mat")]
		mat,
		[Description("glance")]
		glance,
		[Description("semiMat")]
		semiMat,
	}

	public enum PresentingRowType
	{
		collectionHeader,//the root of the tree
		element,//final(leaf) element of data tree
		elementParent,//element which has a child element
		headerGroupOfElements,//contains the list of elements or elementParent or both

		price,//row presents of element price which parent is elementHeader and it cant has a child
		totalPrice,//row represents 
		separator,//empty row - separator
	}

	//TREE STRUCT

	//  collectionHeader
	//      |----headerGroupOfElements
	//                   |----elementParent
	//                              |----element
	//                   |----element
	//                   |----element
	//                   |----element
	//                   |----elementParent
	//                              |----elementParent
	//                                       |----element
	//      |----price
	//      |----totalPrice
	//      |----separator

	public enum BackPanelsFamily
	{
		ordinal,
		middle
	}

	public enum BackPanelType
	{
		plain,
		wiredType1,
		wiredType2,
		perforation,
		MDFpanel,
		DSPpanel
	}

	public enum Material
	{
		MDF,
		DSP,
		wood,
		metall,
		wireMetall,
		glass
	}
}
