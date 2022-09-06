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
	[Parameter] public BorderColorEnum BorderColor { get; set; } = BorderColorEnum.Empty;
	[Parameter] public BorderEnum Border { get; set; } = BorderEnum.Empty;
	[Parameter] public PositionEnum Position { get; set; } = PositionEnum.Empty;
	[Parameter] public EventCallback OnClick { get; set; }
	[Parameter] public string Class { get; set; } = string.Empty;

	private async Task OnClickHandler()
	{
		await OnClick.InvokeAsync();
	}

}