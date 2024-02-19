using BlazorBootstrapComponents.Enums;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBootstrapComponents.Components;

public partial class BSRow
{
    protected override void OnInitialized()
    {
        base.OnInitialized();
        if (Id == null) Id = Guid.NewGuid().ToString();
    }
    [Parameter] public string Class { get; set; }
    [Parameter] public RowVerticalAlignmentEnum VerticalAlign { get; set; } = RowVerticalAlignmentEnum.Start;
    [Parameter] public RenderFragment ChildContent { get; set; }
    [Parameter] public RenderFragment RowTemplate { get; set; }
    [Parameter] public int Gap { get; set; } = 3;
    [Parameter] public string Id { get; set; }
    [Parameter] public string DataBsDismiss { get; set; }
    [Parameter] public string AriaLabel { get; set; }
    [Parameter] public string Type { get; set; }

    private Dictionary<string, object> AdditionalAttributes { get; set; } = new Dictionary<string, object>();

}
