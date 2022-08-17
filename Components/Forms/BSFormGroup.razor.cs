﻿using Microsoft.AspNetCore.Components;
using BlazorBootstrapComponents.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBootstrapComponents.Components.Forms;

public partial class BSFormGroup
{
	[Parameter] public string Class { get; set; } = string.Empty;
	[Parameter] public string Title { get; set; } = string.Empty;
	[Parameter] public BorderColorEnum BorderColor { get; set; } = BorderColorEnum.Empty;
	[Parameter] public BackgroundEnum Background { get; set; } = BackgroundEnum.Empty;
	[Parameter] public RenderFragment ChildContent { get; set; }

	public string Id { get; set; } = Guid.NewGuid().ToString();
}