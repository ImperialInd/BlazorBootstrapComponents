using BlazorBootstrapComponents.Enums;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBootstrapComponents.Components;

public partial class BSLabel
{

    protected override void OnInitialized()
    {
        if (For == string.Empty) throw new Exception("You must supply the [For] id of the control this label belongs to!");

        AdditionalAttributes.Remove("for");
        AdditionalAttributes.Add("for", @For);

        base.OnInitialized();
    }

	[Parameter] public string Class { get; set; } = string.Empty;
	[Parameter] public bool Bold { get; set; }
    [Parameter] public bool IsFormLabel { get; set; }
    [Parameter] public string For { get; set; } = string.Empty;
    [Parameter] public FontSizeEnum FontSize { get; set; } = FontSizeEnum.Empty;
	[Parameter] public ControlSizeEnum Size { get; set; } = ControlSizeEnum.Standard;
	[Parameter] public TextColorEnum Color { get; set; } = TextColorEnum.Empty;
    [Parameter] public RenderFragment ChildContent { get; set; }

    private Dictionary<string, object> AdditionalAttributes { get; set; } = new Dictionary<string, object>();
}
