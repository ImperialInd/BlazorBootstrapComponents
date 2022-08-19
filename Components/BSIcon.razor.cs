using BaseClassLibrary.Enums;
using BlazorBootstrapComponents.Enums;
using Microsoft.AspNetCore.Components;
using System;
using System.Drawing;

namespace BlazorBootstrapComponents.Components;
public partial class BSIcon
{
	[Parameter] public IconNamesEnum Icon { get; set; } = IconNamesEnum.Empty;
	[Parameter] public Color Color { get; set; }
	[Parameter] public string Size { get; set; } = "1rem";
	[Parameter] public Action OnClick { get; set; }
	[Parameter] public string Class { get; set; }
	[Parameter] public string Id { get; set; }
	[Parameter] public RenderFragment ChildContent { get; set; }


	private string GetIconClass()
	{
		string name = Icon.ToString();
		string output = $"{name.Replace('_', '-')}";
		return output;
	}
	private string GetIconColor()
	{
		return $"{this.Color.Name}";
	}
	private void OnClickHandler()
	{
		if (OnClick != null) OnClick.Invoke();
	}
}