using BlazorBootstrapComponents.Enums;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBootstrapComponents.Components;

public partial class BSBadge
{
	[Parameter] public RenderFragment ChildContent { get; set; }
	[Parameter] public bool Pill { get; set; }
	[Parameter] public TextColorEnum TextColor { get; set; } = TextColorEnum.Empty;
	[Parameter] public ContrastColorEnum ContrastColor { get; set; } = ContrastColorEnum.Empty;
	[Parameter] public BackgroundColorEnum BackgroundColor { get; set; } = BackgroundColorEnum.Empty;
	[Parameter] public PositionEnum Position { get; set; } = PositionEnum.Empty;
	[Parameter] public EventCallback OnClick { get; set; }


	private string GetTextColor()
	{
		var output = string.Empty;

		switch (TextColor)
		{
			case TextColorEnum.Empty:
				return "";
			case TextColorEnum.Primary:
				return "text-primary ";
			case TextColorEnum.Secondary:
				return "text-secondary ";
			case TextColorEnum.Success:
				return "text-success ";
			case TextColorEnum.Danger:
				return "text-danger ";
			case TextColorEnum.Warning:
				return "text-warning ";
			case TextColorEnum.Info:
				return "text-info ";
			case TextColorEnum.Light:
				return "text-light ";
			case TextColorEnum.Dark:
				return "text-dark ";
			case TextColorEnum.Body:
				return "text-body ";
			case TextColorEnum.Muted:
				return "text-muted ";
			case TextColorEnum.White:
				return "text-white ";
			default:
				return "";
		}
	}

	private string GetPosition()
	{
		var output = string.Empty;

		switch (Position)
		{
			case PositionEnum.Empty:
				return "";
			case PositionEnum.TopLeft:
				return "position-absolute top-0 start-0 translate-middle";
			case PositionEnum.TopMiddle:
				return "position-absolute top-0 start-50 translate-middle";
			case PositionEnum.TopRight:
				return "position-absolute top-0 start-100 translate-middle";
			case PositionEnum.MiddleLeft:
				return "position-absolute top-50 start-0 translate-middle";
			case PositionEnum.MiddleTop:
				return "position-absolute top-50 start-50 translate-middle";
			case PositionEnum.MiddleRight:
				return "position-absolute top-50 start-100 translate-middle";
			case PositionEnum.BottomLeft:
				return "position-absolute top-100 start-0 translate-middle";
			case PositionEnum.BottomTop:
				return "position-absolute top-100 start-50 translate-middle";
			case PositionEnum.BottomRight:
				return "position-absolute top-100 start-100 translate-middle";
			default:
				return "";
		}
	}

	private async Task OnClickHandler()
	{
		await OnClick.InvokeAsync();
	}

}