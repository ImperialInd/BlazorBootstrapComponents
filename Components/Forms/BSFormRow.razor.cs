﻿using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBootstrapComponents.Components.Forms;

public partial class BSFormRow
{

	[Parameter] public string Class { get; set; }
	[Parameter] public RenderFragment ChildContent { get; set; }
	[Parameter] public RenderFragment RowTemplate { get; set; }
}
