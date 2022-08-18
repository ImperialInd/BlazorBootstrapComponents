﻿using BlazorBootstrapComponents.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBootstrapComponents;

public static class GenerateFunctions
{
	public static string GenerateBackgroundColor(BackgroundEnum BackgroundColor)
	{
		return BackgroundColor switch
		{
			>= BackgroundEnum.Primary and <= BackgroundEnum.Transparent => $"bg-{BackgroundColor.ToString().ToLower()} ",
			_ => "",
		};
	}

	public static string GenerateBorderColor(BorderColorEnum BorderColor)
	{
		return BorderColor switch
		{
			>= BorderColorEnum.Primary and <= BorderColorEnum.White => $"border-{BorderColor.ToString().ToLower()} ",
			_ => "",
		};
	}

	public static int[] GenerateWidth(int XS = -1, int S = -1, int M = -1, int L = -1, int XL = -1, int XXL = -1)
	{
		int[] output = new int[] { XS, S, M, L, XL, XXL };

		return output;
	}
	public static int[] GenerateWidthAll(int Width = -1)
	{
		int[] output = new int[] { Width, -1, -1, -1, -1, -1 };

		return output;
	}

	public static string GenerateColumnWidth(int[] MediaWidth)
	{
		string output = String.Empty;

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

		if (output.Length == 0) output = "col ";
		return output;

	}

	public static TextAlignmentEnum[] GenerateTextAlignment(TextAlignmentEnum XS = TextAlignmentEnum.Empty, TextAlignmentEnum S = TextAlignmentEnum.Empty, TextAlignmentEnum M = TextAlignmentEnum.Empty, TextAlignmentEnum L = TextAlignmentEnum.Empty, TextAlignmentEnum XL = TextAlignmentEnum.Empty, TextAlignmentEnum XXL = TextAlignmentEnum.Empty)
	{
		TextAlignmentEnum[] output = new TextAlignmentEnum[] { XS, S, M, L, XL, XXL };

		return output;
	}

	public static TextAlignmentEnum[] GenerateTextAlignmentAll(TextAlignmentEnum Alignment = TextAlignmentEnum.Empty)
	{
		TextAlignmentEnum[] output = new TextAlignmentEnum[] { Alignment, TextAlignmentEnum.Empty, TextAlignmentEnum.Empty, TextAlignmentEnum.Empty, TextAlignmentEnum.Empty, TextAlignmentEnum.Empty };

		return output;
	}

	public static string GenerateTextAlignment(TextAlignmentEnum[] MediaAlignment)
	{
		string output = String.Empty;

		if (MediaAlignment[0] != TextAlignmentEnum.Empty) output += $"text-{MediaAlignment[0].ToString().ToLower()} ";
		if (MediaAlignment[1] != TextAlignmentEnum.Empty) output += $"text-sm-{MediaAlignment[1].ToString().ToLower()} ";
		if (MediaAlignment[2] != TextAlignmentEnum.Empty) output += $"text-md-{MediaAlignment[2].ToString().ToLower()} ";
		if (MediaAlignment[3] != TextAlignmentEnum.Empty) output += $"text-lg-{MediaAlignment[3].ToString().ToLower()} ";
		if (MediaAlignment[4] != TextAlignmentEnum.Empty) output += $"text-xl-{MediaAlignment[4].ToString().ToLower()} ";
		if (MediaAlignment[5] != TextAlignmentEnum.Empty) output += $"text-xxl-{MediaAlignment[5].ToString().ToLower()} ";

		return output;

	}


	public static string GenerateBorder(BorderEnum Border)
	{
		return Border switch
		{
			BorderEnum.ShowAll => "border ",
			BorderEnum.ShowTop => "border-top ",
			BorderEnum.ShowEnd => "border-end ",
			BorderEnum.ShowBottom => "border-bottom ",
			BorderEnum.ShowStart => "border-start ",
			BorderEnum.HideAll => "border-0 ",
			BorderEnum.HideTop => "border-top-0 ",
			BorderEnum.HideEnd => "border-end-0 ",
			BorderEnum.HideBottom => "border-bottom-0 ",
			BorderEnum.HideStart => "border-start-0 ",
			_ => "",
		};
	}

	public static string GenerateFontSize(FontSizeEnum Size)
	{
		return Size switch
		{
			FontSizeEnum.S1 => "fs-1 ",
			FontSizeEnum.S2 => "fs-2 ",
			FontSizeEnum.S3 => "fs-3 ",
			FontSizeEnum.S4 => "fs-4 ",
			FontSizeEnum.S5 => "fs-5 ",
			FontSizeEnum.S6 => "fs-6 ",
			_ => "",
		};
	}

	public static string GenerateTextColor(TextColorEnum Color)
	{
		return Color switch
		{
			TextColorEnum.Primary => "text-primary ",
			TextColorEnum.Secondary => "text-secondary ",
			TextColorEnum.Success => "text-success ",
			TextColorEnum.Danger => "text-danger ",
			TextColorEnum.Warning => "text-warning ",
			TextColorEnum.Info => "text-info ",
			TextColorEnum.Light => "text-light ",
			TextColorEnum.Dark => "text-dark ",
			TextColorEnum.Body => "text-body ",
			TextColorEnum.Muted => "text-muted ",
			TextColorEnum.White => "text-white ",
			_ => "",
		};
	}

	public static string GenerateWidth(WidthEnum Width)
	{
		return Width switch
		{
			WidthEnum.Empty => "",
			WidthEnum.W_100 => "w-100 ",
			WidthEnum.W_75 => "w-75 ",
			WidthEnum.W_50 => "w-50 ",
			WidthEnum.W_25 => "w-25 ",
			_ => "",
		};
	}

	public static string GenerateFormControlSize(FormControlSizeEnum Size)
	{
		return Size switch
		{
			FormControlSizeEnum.Large => "form-control-lg ",
			FormControlSizeEnum.Small => "form-control-sm ",
			_ => "",
		};
	}
	public static string GenerateFormLabelControlSize(FormControlSizeEnum Size)
	{
		return Size switch
		{
			FormControlSizeEnum.Large => "col-form-label-lg ",
			FormControlSizeEnum.Small => "col-form-label-sm ",
			_ => "",
		};
	}

}
