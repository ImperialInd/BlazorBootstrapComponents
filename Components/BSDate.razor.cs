using BaseClassLibrary.Classes;
using BlazorBootstrapComponents.Enums;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBootstrapComponents.Components;

public partial class BSDate
{
    protected override void OnInitialized()
    {
        if (ValueExpression != null) _fieldIdentifier = FieldIdentifier.Create(ValueExpression);
        if (Id == null || Id == string.Empty) Id = Guid.NewGuid().ToString();
        base.OnInitialized();
    }

    private FieldIdentifier _fieldIdentifier;
    private string _fieldCssClasses => CascadedEditContext?.FieldCssClass(_fieldIdentifier) ?? "";

    [CascadingParameter] private EditContext CascadedEditContext { get; set; }

    [Parameter] public DateTime? Value { get; set; }
    [Parameter] public EventCallback<DateTime?> ValueChanged { get; set; }
    [Parameter] public Expression<Func<DateTime?>> ValueExpression { get; set; }

    [Parameter] public EventCallback<DateTime?> OnChange { get; set; }

    [Parameter] public string Class { get; set; } = string.Empty;
    [Parameter] public BackgroundColorEnum Background { get; set; } = BackgroundColorEnum.Empty;
    [Parameter] public ControlSizeEnum Size { get; set; } = ControlSizeEnum.Standard;
    [Parameter] public bool Disabled { get; set; }
    [Parameter] public bool ReadOnly { get; set; }
    [Parameter] public bool Required { get; set; }
    [Parameter] public string Title { get; set; } = string.Empty;
    [Parameter] public string Id { get; set; }
    [Parameter] public bool FloatingLabel { get; set; }
    [Parameter] public string PlaceHolder { get; set; } = string.Empty;
    [Parameter] public bool HorizontalLayout { get; set; }
    [Parameter] public int[] MediaWidthLabel { get; set; } = new int[] { -1, -1, -1, -1, -1, -1 };
    [Parameter] public int[] MediaWidth { get; set; } = new int[] { -1, -1, -1, -1, -1, -1 };
    [Parameter] public TextAlignmentEnum[] MediaLabelAlignment { get; set; } = new TextAlignmentEnum[] { TextAlignmentEnum.Empty, TextAlignmentEnum.Empty, TextAlignmentEnum.Empty, TextAlignmentEnum.Empty, TextAlignmentEnum.Empty, TextAlignmentEnum.Empty };

    private Dictionary<string, object> AdditionalAttributes { get; set; } = new Dictionary<string, object>();

    private async Task OnChangeHandler(ChangeEventArgs args)
    {
        DateTime? output = (DateTime?)args.Value;
        await ValueChanged.InvokeAsync(output);
        await OnChange.InvokeAsync(output);
        CascadedEditContext?.NotifyFieldChanged(_fieldIdentifier);
    }

}
