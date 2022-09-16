using Microsoft.AspNetCore.Components;
using BlazorBootstrapComponents.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBootstrapComponents.Components;

public partial class BSGroup
{
	[Parameter] public string Class { get; set; } = string.Empty;
	[Parameter] public string Title { get; set; } = string.Empty;
	[Parameter] public TextColorEnum TitleColor { get; set; } = TextColorEnum.Empty;
	[Parameter] public FontSizeEnum TitleSize { get; set; } = FontSizeEnum.Empty;
	[Parameter] public BorderColorEnum BorderColor { get; set; } = BorderColorEnum.Empty;
	[Parameter] public BackgroundColorEnum Background { get; set; } = BackgroundColorEnum.Empty;
	[Parameter] public RenderFragment ChildContent { get; set; }
	[Parameter] public ShadowEnum Shadow { get; set; } = ShadowEnum.None;
	[Parameter] public int Gap { get; set; } = 1;


	public string Id { get; set; } = Guid.NewGuid().ToString();
}
