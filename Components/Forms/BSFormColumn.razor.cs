using BlazorBootstrapComponents.Enums;
using Dapper.Core.Supporting;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBootstrapComponents.Components.Forms;

public partial class BSFormColumn
{
	[Parameter] public string Class { get; set; } = String.Empty;
	[Parameter] public int[] MediaOffset { get; set; } = new int[] { -1, -1, -1, -1, -1, -1 };
	[Parameter] public int[] MediaWidth { get; set; } = new int[] { -1, -1, -1, -1, -1, -1 };
	[Parameter] public bool AutoSize { get; set; }
	[Parameter] public int[] MediaOrder { get; set; } = new int[] { -2, -2, -2, -2, -2, -2 };
	[Parameter] public ColumnVerticalAlignmentEnum VerticalAlignment { get; set; } = ColumnVerticalAlignmentEnum.Empty;
	[Parameter] public RenderFragment ChildContent { get; set; }


	/// <summary>
	/// Assign 0 to use col, col-xs, ... etc
	/// Other values are 1 - 12
	/// </summary>
	/// <param name="XS">Extra Small Breakpoint</param>
	/// <param name="S">Small Breakpoint</param>
	/// <param name="M">Medium Breakpoint</param>
	/// <param name="L">Large Breakpoint</param>
	/// <param name="XL">Extra Large Breakpoint</param>
	/// <param name="XXL">Extra Extra Large Breakpoint</param>
	/// <returns></returns>
	public static int[] GetWidth(int XS = -1, int S = -1, int M = -1, int L = -1, int XL = -1, int XXL = -1)
	{
		int[] output = new int[] { XS, S, M, L, XL, XXL };

		return output;
	}
	public static int[] GetWidthAll(int Width = -1)
	{
		int[] output = new int[] { Width, -1, -1, -1, -1, -1 };

		return output;
	}
	private string GenerateWidth()
	{
		string output = String.Empty;

		if (AutoSize)
		{
			output += "col-auto ";
		}
		else
		{
			if (MediaWidth[0] == 0) output += $"col ";
			if (MediaWidth[0] > 0) output += $"col-{MediaWidth[0]} ";
			if (MediaWidth[1] == 0) output += $"col-sm ";
			if (MediaWidth[1] > 0) output += $"col-sm-{MediaWidth[1]} ";
			if (MediaWidth[2] == 0) output += $"col-md ";
			if (MediaWidth[2] > 0) output += $"col-md-{MediaWidth[2]} ";
			if (MediaWidth[3] == 0) output += $"col-lg ";
			if (MediaWidth[3] > 0) output += $"col-lg-{MediaWidth[3]} ";
			if (MediaWidth[4] == 0) output += $"col-xl ";
			if (MediaWidth[4] > 0) output += $"col-xl-{MediaWidth[4]} ";
			if (MediaWidth[5] == 0) output += $"col-xxl ";
			if (MediaWidth[5] > 0) output += $"col-xxl-{MediaWidth[5]} ";
		}

		if (output.Length == 0) output = "col ";
		return output;

	}

	public static int[] GetOffset(int XS = -1, int S = -1, int M = -1, int L = -1, int XL = -1, int XXL = -1)
	{
		int[] output = new int[] { XS, S, M, L, XL, XXL };
		return output;
	}
	public static int[] GetOffsetAll(int Offset = -1)
	{
		int[] output = new int[] { Offset, -1, -1, -1, -1, -1 };
		return output;
	}

	private string GenerateOffset()
	{
		string output = string.Empty;

		if (MediaOffset[0] > -1) output += $"offset-{MediaOffset[0]} ";
		if (MediaOffset[1] > -1) output += $"offset-sm-{MediaOffset[1]} ";
		if (MediaOffset[2] > -1) output += $"offset-md-{MediaOffset[2]} ";
		if (MediaOffset[3] > -1) output += $"offset-lg-{MediaOffset[3]} ";
		if (MediaOffset[4] > -1) output += $"offset-xl-{MediaOffset[4]} ";
		if (MediaOffset[5] > -1) output += $"offset-xxl-{MediaOffset[5]} ";

		return output;

	}

	public static int[] GetOrder(int XS = -2, int S = -2, int M = -2, int L = -2, int XL = -2, int XXL = -2)
	{
		// Validate the order
		string msg1 = "You cannot have a value greater then 5 for order!";
		if (XS > 5) throw new Exception(msg1);
		if (S > 5) throw new Exception(msg1);
		if (M > 5) throw new Exception(msg1);
		if (L > 5) throw new Exception(msg1);
		if (XL > 5) throw new Exception(msg1);
		if (XXL > 5) throw new Exception(msg1);

		string msg2 = "You cannot have a value less then -1 for order!";
		if (XS < -2) throw new Exception(msg2);
		if (S < -2) throw new Exception(msg2);
		if (M < -2) throw new Exception(msg2);
		if (L < -2) throw new Exception(msg2);
		if (XL < -2) throw new Exception(msg2);
		if (XXL < -2) throw new Exception(msg2);

		int[] output = new int[] { XS, S, M, L, XL, XXL };
		return output;
	}

	private string GenerateOrder()
	{
		string output = string.Empty;

		switch (MediaOrder[0])
		{
			case -2:
				break;
			case -1:
				output += "order-first ";
				break;
			case 0:
				output += "order-last ";
				break;
			default:
				output += $"order-{MediaOrder[0]} ";
				break;
		}

		switch (MediaOrder[1])
		{
			case -2:
				break;
			case -1:
				output += "order-sm-first ";
				break;
			case 0:
				output += "order-sm-last ";
				break;
			default:
				output += $"order-sm-{MediaOrder[1]} ";
				break;
		}

		switch (MediaOrder[2])
		{
			case -2:
				break;
			case -1:
				output += "order-md-first ";
				break;
			case 0:
				output += "order-md-last ";
				break;
			default:
				output += $"order-md-{MediaOrder[2]} ";
				break;
		}

		switch (MediaOrder[3])
		{
			case -2:
				break;
			case -1:
				output += "order-lg-first ";
				break;
			case 0:
				output += "order-lg-last ";
				break;
			default:
				output += $"order-lg-{MediaOrder[3]} ";
				break;
		}

		switch (MediaOrder[4])
		{
			case -2:
				break;
			case -1:
				output += "order-xl-first ";
				break;
			case 0:
				output += "order-xl-last ";
				break;
			default:
				output += $"order-xl-{MediaOrder[4]} ";
				break;
		}

		switch (MediaOrder[5])
		{
			case -2:
				break;
			case -1:
				output += "order-xxl-first ";
				break;
			case 0:
				output += "order-xxl-last ";
				break;
			default:
				output += $"order-xxl-{MediaOrder[5]} ";
				break;
		}

		return output.TrimStart();
	}

	private string GenerateVerticalAlignment()
	{
		switch (VerticalAlignment)
		{
			case ColumnVerticalAlignmentEnum.Empty:
				return "";
			case ColumnVerticalAlignmentEnum.Start:
				return "align-self-start ";
			case ColumnVerticalAlignmentEnum.Center:
				return "align-self-center ";
			case ColumnVerticalAlignmentEnum.End:
				return "align-self-end ";
			default:
				return "";
		}
	}


}

