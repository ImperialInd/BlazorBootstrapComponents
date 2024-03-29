﻿using BaseClassLibrary.Classes;
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

public partial class BSTextArea
{
	protected override void OnInitialized()
	{
		fieldIdentifier = FieldIdentifier.Create(ValueExpression);
		if (Id == null || Id == string.Empty) Id = Guid.NewGuid().ToString();

		if (Id == null || Id == string.Empty) Id = Guid.NewGuid().ToString();
		if (FeedbackInValid.Length > 0 || FeedbackValid.Length > 0) FeedbackId = Guid.NewGuid().ToString();
		base.OnInitialized();
	}

	private FieldIdentifier fieldIdentifier;
	private string FieldCssClasses => CascadedEditContext?.FieldCssClass(fieldIdentifier) ?? "";

	[CascadingParameter] private EditContext CascadedEditContext { get; set; }

	[Parameter] public string Class { get; set; } = string.Empty;

	[Parameter] public string Value { get; set; }
	[Parameter] public EventCallback<string> ValueChanged { get; set; }
	[Parameter] public Expression<Func<string>> ValueExpression { get; set; }
	[Parameter] public EventCallback<string> OnChange { get; set; }

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

	private async void OnChangeHandler(ChangeEventArgs args)
	{
		string input = (string)args.Value;

		if (input.Length == 0)
		{
			Value = default;
			await ValueChanged.InvokeAsync(default);
			await OnChange.InvokeAsync(default);
			CascadedEditContext?.NotifyFieldChanged(fieldIdentifier);
		}
		else
		{
			string output = input;
			await ValueChanged.InvokeAsync(output);
			await OnChange.InvokeAsync(output);
			CascadedEditContext?.NotifyFieldChanged(fieldIdentifier);
		}
	}

}
