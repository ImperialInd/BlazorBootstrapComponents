using BlazorBootstrapComponents.Enums;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using System.Linq.Expressions;
using System.Text;

namespace BlazorBootstrapComponents.Components;

public class BSSelect<TItem, TValue> : ComponentBase
{
    protected override void OnInitialized()
    {
        if (ValueExpression != null) fieldIdentifier = FieldIdentifier.Create(ValueExpression);
        if (Id == null || Id == string.Empty) Id = Guid.NewGuid().ToString();

        base.OnInitialized();
    }

    private FieldIdentifier fieldIdentifier;
    private string FieldCssClasses => CascadedEditContext?.FieldCssClass(fieldIdentifier) ?? "";

    [CascadingParameter] private EditContext CascadedEditContext { get; set; }

    [Parameter] public IEnumerable<TItem> Data { get; set; }
    [Parameter] public TValue Value { get; set; }
    [Parameter] public EventCallback<TValue> ValueChanged { get; set; }
    [Parameter] public Expression<Func<TValue>> ValueExpression { get; set; }

    [Parameter] public string TextField { get; set; }
    [Parameter] public string ValueField { get; set; }

    [Parameter] public EventCallback<TValue> OnChange { get; set; }
    [Parameter] public string Class { get; set; }

    [Parameter] public bool Disabled { get; set; }
    [Parameter] public string DisabledField { get; set; }

    [Parameter] public string Id { get; set; }
    [Parameter] public string PlaceHolder { get; set; }

    [Parameter] public string Width { get; set; }
    [Parameter] public ControlSizeEnum Size { get; set; } = ControlSizeEnum.Standard;
    [Parameter] public int ListSize { get; set; }

    [Parameter] public string Label { get; set; }
    [Parameter] public bool LabelFloating { get; set; }
    [Parameter] public bool Inline { get; set; }



    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        int seq = -1;
        bool foundValue = false;

        if (LabelFloating == false && Label != null)
        {
            builder.OpenElement(++seq, "label");
            builder.AddAttribute(++seq, "for", Id);
            builder.AddContent(++seq, Label);
            builder.CloseElement(); // close label
        }

        if (LabelFloating && Label != null)
        {
            builder.OpenElement(++seq, "div");
            builder.AddAttribute(++seq, "class", "form-floating");
        }

        builder.OpenElement(++seq, "select");
        builder.AddAttribute(++seq, "id", Id);
        builder.AddAttribute(++seq, "class", GetClass());
        builder.AddAttribute(++seq, "onchange", EventCallback.Factory.Create(this, OnChangeHandler));
        builder.AddAttribute(++seq, "disabled", Disabled);
        builder.AddAttribute(++seq, "style", GetStyle());
        if (ListSize > 0) builder.AddAttribute(++seq, "size", ListSize.ToString());

        if (PlaceHolder != null)
        {
            builder.OpenElement(++seq, "option");
            builder.AddAttribute(++seq, "selected", !foundValue);
            builder.AddContent(++seq, PlaceHolder);
            builder.CloseElement(); // close option
        }

        foreach (var item in Data)
        {
            var text = item.GetType().GetProperty(TextField)?.GetValue(item)?.ToString();
            var value = item.GetType().GetProperty(ValueField)?.GetValue(item);
            var isSelected = value.Equals(Value);
            var disabled = DisabledField != null && (bool)item.GetType().GetProperty(DisabledField)?.GetValue(item);

            builder.OpenElement(++seq, "option");
            builder.AddAttribute(++seq, "value", value);
            builder.AddAttribute(++seq, "selected", isSelected);
            builder.AddAttribute(++seq, "disabled", disabled);
            builder.AddContent(++seq, text);
            builder.CloseElement(); // close option
        }

        builder.CloseElement(); // close select

        if (LabelFloating && Label != null)
        {
            builder.OpenElement(++seq, "label");
            builder.AddAttribute(++seq, "for", Id);
            builder.AddContent(++seq, Label);
            builder.CloseElement(); // close label
            builder.CloseElement(); // close div for floating label
        }

    }

    private string GetClass()
    {
        StringBuilder output = new();

        output.Append("form-select ");
        if (Class != null)
        {
            output.Append(Class);
            output.Append(' ');
        }

        switch (Size)
        {
            case ControlSizeEnum.Large:
                output.Append(" form-select-lg");
        output.Append(' ');
                break;
            case ControlSizeEnum.Small:
                output.Append(" form-select-sm");
        output.Append(' ');
                break;
            case ControlSizeEnum.Standard:
            default:
                break;
        }

        output.Append(FieldCssClasses);

        return output.ToString().Trim();
    }

    private string GetStyle()
    {
        StringBuilder output = new();

        if (Inline)
        {
            output.Append("display:inline-block; ");
        }

        if (Width != null)
        {
            output.Append("width: ");
            output.Append(Width);
            output.Append("; ");
        }

        return output.ToString().Trim();
    }

    private async Task OnChangeHandler(ChangeEventArgs args)
    {
        TValue output;

        output = (TValue)Convert.ChangeType(args.Value, typeof(TValue));
        Value = output;
        await ValueChanged.InvokeAsync(Value);
        await OnChange.InvokeAsync(Value);
        CascadedEditContext?.NotifyFieldChanged(fieldIdentifier);
    }

}
