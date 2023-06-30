using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBootstrapComponents.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;
    using Microsoft.AspNetCore.Components.Forms;

    public class BSRadio<TValue> : ComponentBase
    {
        private FieldIdentifier fieldIdentifier;
        private string FieldCssClasses => CascadedEditContext?.FieldCssClass(fieldIdentifier) ?? "";

        [CascadingParameter] private EditContext CascadedEditContext { get; set; }

        [Parameter] public TValue Value { get; set; }
        [Parameter] public EventCallback<TValue> ValueChanged { get; set; }
        [Parameter] public Expression<Func<TValue>> ValueExpression { get; set; }
        [Parameter] public EventCallback<TValue> OnChange { get; set; }
        [Parameter] public TValue SelectedValue { get; set; }
        [Parameter] public string GroupName { get; set; }
        [Parameter] public string Id { get; set; }
        [Parameter] public string Label { get; set; }
        [Parameter] public bool Disabled { get; set; }
        [Parameter] public bool Inline { get; set; }
        [Parameter] public string Class { get; set; }
        [Parameter] public Dictionary<string, object> AdditionalAttributes { get; set; } = new Dictionary<string, object>();

        protected override void OnInitialized()
        {
            if (GroupName == null) throw new Exception("You must supply the [GroupName] for the Radio Group!");
            fieldIdentifier = FieldIdentifier.Create(ValueExpression);
            if (Id == null || Id == string.Empty) Id = Guid.NewGuid().ToString();
            base.OnInitialized();
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            // Render the div
            builder.OpenElement(0, "div");
            builder.AddAttribute(1, "class", $"form-check {(Inline ? "form-check-inline " : "")}");

            // Render the input
            builder.OpenElement(2, "input");
            builder.AddMultipleAttributes(3, AdditionalAttributes);
            builder.AddAttribute(4, "class", $"form-check-input {FieldCssClasses}");
            builder.AddAttribute(5, "type", "radio");
            builder.AddAttribute(6, "name", GroupName);
            builder.AddAttribute(7, "id", Id);
            builder.AddAttribute(8, "value", SelectedValue);
            builder.AddAttribute(9, "checked", Value.Equals(SelectedValue));
            builder.AddAttribute(10, "disabled", Disabled == true);
            builder.AddAttribute(11, "onchange", EventCallback.Factory.Create(this, () => RadioOnChangeHandler(SelectedValue)));
            builder.CloseElement();

            // Render the label
            if (Label != null)
            {
                builder.OpenElement(12, "label");
                builder.AddAttribute(13, "class", "form-check-label");
                builder.AddAttribute(14, "for", Id);
                builder.AddContent(15, Label);
                builder.CloseElement();
            }

            builder.CloseElement();
        }

        private async void RadioOnChangeHandler(TValue value)
        {
            await ValueChanged.InvokeAsync(value);
            await OnChange.InvokeAsync(value);
        }
    }
}
