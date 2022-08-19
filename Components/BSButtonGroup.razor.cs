using BlazorBootstrapComponents.Enums;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBootstrapComponents.Components;

public partial class BSButtonGroup
{
	[Parameter] public ButtonGroupSizeEnum Size { get; set; } = ButtonGroupSizeEnum.Standard;
	[Parameter] public RenderFragment ChildContent { get; set; }
	[Parameter] public bool Vertical { get; set; }

	[Parameter]
	public bool Disabled
	{
		get
		{
			bool output = AllOtherAttributes.ContainsKey("disabled");
			return output;
		}
		set
		{
			AllOtherAttributes.Remove("disabled");
			AllOtherAttributes.Add("disabled", true);
		}
	}

	[Parameter(CaptureUnmatchedValues = true)]
	public Dictionary<string, object> AllOtherAttributes { get; set; } = new Dictionary<string, object>();

	private string GetButtonGroupSize()
	{
		var output = string.Empty;

		switch (Size)
		{
			case ButtonGroupSizeEnum.Large:
				return "btn-group-lg ";
			case ButtonGroupSizeEnum.Small:
				return "btn-group-sm ";
			case ButtonGroupSizeEnum.Standard:
			default:
				return "";
		}
	}
}