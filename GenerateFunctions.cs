using BlazorBootstrapComponents.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBootstrapComponents;

public static class GenerateFunctions
{
	public static string GenerateBackgroundColor(BackgroundEnum BackgroundColor)
	{
		switch (BackgroundColor)
		{
			case >= BackgroundEnum.primary and <= BackgroundEnum.transparent:
				return $"bg-{BackgroundColor.ToString()} ";
			case BackgroundEnum.Empty:
			default:
				return "";
		}
	}

	public static string GenerateBorderColor(BorderColorEnum BorderColor)
	{
		switch (BorderColor)
		{
			case >= BorderColorEnum.primary and <= BorderColorEnum.white:
				return $"border-{BorderColor.ToString()} ";
			case BorderColorEnum.Empty:
			default:
				return "";
		}
	}

	public static string GenerateBorder(BorderEnum Border)
	{
		switch (Border)
		{
			case BorderEnum.ShowAll:
				return "border ";
			case BorderEnum.ShowTop:
				return "border-top ";
			case BorderEnum.ShowEnd:
				return "border-end ";
			case BorderEnum.ShowBottom:
				return "border-bottom ";
			case BorderEnum.ShowStart:
				return "border-start ";
			case BorderEnum.HideAll:
				return "border-0 ";
			case BorderEnum.HideTop:
				return "border-top-0 ";
			case BorderEnum.HideEnd:
				return "border-end-0 ";
			case BorderEnum.HideBottom:
				return "border-bottom-0 ";
			case BorderEnum.HideStart:
				return "border-start-0 ";
			case BorderEnum.Empty:
			default:
				return "";
		}
	}

}
