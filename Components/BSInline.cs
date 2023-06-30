using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using BlazorBootstrapComponents.Extensions;

namespace BlazorBootstrapComponents.Components;

public class BSInline : ComponentBase
{
    [Parameter] public string Label { get; set; }
    [Parameter] public RenderFragment ChildContent { get; set; }

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> AdditionalAttributes { get; set; } = new Dictionary<string, object>();

    public string Id { get; set; } = Guid.NewGuid().ToString();

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        base.BuildRenderTree(builder);

        builder.OpenElement(0, "div");
        builder.AddAttribute(1, "id", Id);
        builder.AddMultipleAttributes(2, AdditionalAttributes);

        if (!string.IsNullOrEmpty(Label))
        {
            builder.OpenElement(3, "label");
            builder.AddAttribute(4, "style", "display:inline-block;");
            builder.AddAttribute(5, "class", "col-form-label mr-1");
            builder.AddAttribute(6, "for", Id);
            builder.AddContent(7, $"{Label}".NonBreakingSpace());
            builder.CloseElement();
        }

        builder.OpenElement(8, "div");
        builder.AddAttribute(9, "style", "display:inline-block;");
        builder.AddContent(10, ChildContent);
        builder.CloseElement();

        builder.CloseElement();
    }
}
