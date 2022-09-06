using BaseClassLibrary.Enums;
using BlazorBootstrapComponents.Enums;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BlazorBootstrapComponents.Components;
public partial class BSButton
{
	[Parameter] public ButtonBackgroundEnum BackgroundColor { get; set; } = ButtonBackgroundEnum.Light;
	[Parameter] public string Class { get; set; } = string.Empty;
	[Parameter] public RenderFragment ChildContent { get; set; }
	[Parameter] public bool DisableTextWrapping { get; set; }
	[Parameter] public ButtonOutlineColorEnum OutlineColor { get; set; } = ButtonOutlineColorEnum.Empty;
	[Parameter] public ControlSizeEnum Size { get; set; } = ControlSizeEnum.Standard;
	[Parameter] public string Width { get; set; } = string.Empty;
	[Parameter] public string Height { get; set; } = string.Empty;
	[Parameter] public bool Bold { get; set; }
	[Parameter] public bool Underline { get; set; }
	[Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object> AdditionalAttributes { get; set; } = new Dictionary<string, object>();
	[Parameter] public EventCallback OnClick { get; set; }
	[Parameter] public EventCallback OnDoubleClick { get; set; }
	[Parameter] public IconNamesEnum Icon { get; set; } = IconNamesEnum.Empty;

	private bool _asClose;
	[Parameter]
	public bool AsClose
	{
		get { return _asClose; }
		set { _asClose = value; }
	}

	private bool _asAlertClose;
	[Parameter]
	public bool AsAlertClose
	{
		get { return _asAlertClose; }
		set { _asAlertClose = value; }
	}


	[Parameter]
	public bool Disabled
	{
		get { return _disabled; }
		set { _disabled = value; }
	}
	private bool _disabled;

	private string GetButtonBackgroundColor()
	{
		return BackgroundColor switch
		{
			ButtonBackgroundEnum.Primary => "btn-primary ",
			ButtonBackgroundEnum.Secondary => "btn-secondary ",
			ButtonBackgroundEnum.Success => "btn-success ",
			ButtonBackgroundEnum.Danger => "btn-danger ",
			ButtonBackgroundEnum.Warning => "btn-warning ",
			ButtonBackgroundEnum.Info => "btn-info ",
			ButtonBackgroundEnum.Light => "btn-light ",
			ButtonBackgroundEnum.Dark => "btn-dark ",
			ButtonBackgroundEnum.Link => "btn-link ",
			_ => "",
		};
	}

	private string GetButtonOutlineColor()
	{
		return OutlineColor switch
		{
			ButtonOutlineColorEnum.Primary => "btn-outline-primary ",
			ButtonOutlineColorEnum.Secondary => "btn-outline-secondary ",
			ButtonOutlineColorEnum.Success => "btn-outline-success ",
			ButtonOutlineColorEnum.Danger => "btn-outline-danger ",
			ButtonOutlineColorEnum.Warning => "btn-outline-warning ",
			ButtonOutlineColorEnum.Info => "btn-outline-info ",
			ButtonOutlineColorEnum.Light => "btn-outline-light ",
			ButtonOutlineColorEnum.Dark => "btn-outline-dark ",
			_ => "",
		};
	}

	private string GetButtonSize()
	{
		return Size switch
		{
			ControlSizeEnum.Standard => "",
			ControlSizeEnum.Large => "btn-lg ",
			ControlSizeEnum.Small => "btn-sm ",
			_ => "",
		};
	}

	private async Task OnClickHandler()
	{
		await OnClick.InvokeAsync();
	}

	private async Task OnDoubleClickHandler()
	{
		await OnDoubleClick.InvokeAsync();
	}
}