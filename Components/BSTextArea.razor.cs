using BlazorBootstrapComponents.Enums;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBootstrapComponents.Components;

public partial class BSTextArea
{
	protected override void OnInitialized()
	{
		if (Id == null || Id == string.Empty) Id = Guid.NewGuid().ToString();
		if (FeedbackInValid.Length > 0 || FeedbackValid.Length > 0) FeedbackId = Guid.NewGuid().ToString();
		base.OnInitialized();
	}
[Parameter] public string Class { get; set; } = string.Empty;
	private string _Value;

	[Parameter]
	public string Value
	{
		get => _Value;
		set
		{
			if (_Value == value) return;
			_Value = value;
			ValueChanged.InvokeAsync(value);
		}
	}
	[Parameter] public EventCallback<string> ValueChanged { get; set; }
	[Parameter] public BackgroundColorEnum Background { get; set; } = BackgroundColorEnum.Empty;
	[Parameter] public ControlSizeEnum Size { get; set; } = ControlSizeEnum.Standard;
	[Parameter] public string Title { get; set; }
	[Parameter] public string Id { get; set; }
	[Parameter] public bool FloatingLabel { get; set; }
	[Parameter] public string PlaceHolder { get; set; }
	[Parameter] public bool AutoComplete { get; set; }
	[Parameter] public bool Disabled { get; set; }
	[Parameter] public bool ReadOnly { get; set; }
	[Parameter] public bool Required { get; set; }
	[Parameter] public string FeedbackValid { get; set; } = string.Empty;
	[Parameter] public string FeedbackInValid { get; set; } = string.Empty;

	[Parameter] public int Rows { get; set; } = 3;
	[Parameter] public bool HorizontalLayout { get; set; }
	[Parameter] public int[] MediaWidthLabel { get; set; } = new int[] { -1, -1, -1, -1, -1, -1 };
	[Parameter] public int[] MediaWidthTextBox { get; set; } = new int[] { -1, -1, -1, -1, -1, -1 };
	[Parameter] public TextAlignmentEnum[] MediaLabelAlignment { get; set; } = new TextAlignmentEnum[] { TextAlignmentEnum.Empty, TextAlignmentEnum.Empty, TextAlignmentEnum.Empty, TextAlignmentEnum.Empty, TextAlignmentEnum.Empty, TextAlignmentEnum.Empty };

	public string FeedbackId { get; set; } = string.Empty;
	private Dictionary<string, object> AdditionalAttributes { get; set; } = new Dictionary<string, object>();

	private async void ValueChangedHandler(ChangeEventArgs args)
	{
		Value = args.Value as string;
		await ValueChanged.InvokeAsync(Value);
	}

}
