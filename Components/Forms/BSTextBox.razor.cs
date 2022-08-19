using BlazorBootstrapComponents.Enums;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBootstrapComponents.Components.Forms;

public partial class BSTextBox
{
	protected override void OnInitialized()
	{
		if (Id == null || Id == string.Empty) Id = Guid.NewGuid().ToString();
		base.OnInitialized();
	}
	[Parameter] public bool AddMargin { get; set; } = true;
	[Parameter] public string Value { get; set; }
	[Parameter] public BackgroundColorEnum Background { get; set; } = BackgroundColorEnum.Empty;
	[Parameter] public FormControlSizeEnum Size { get; set; } = FormControlSizeEnum.Standard;
	[Parameter] public string Title { get; set; }
	[Parameter] public string Id { get; set; }
	[Parameter] public bool FloatingLabel { get; set; }
	[Parameter] public bool HorizontalLayout { get; set; }
	[Parameter] public string PlaceHolder { get; set; }
	[Parameter] public bool AutoComplete { get; set; }
	[Parameter] public int[] MediaWidthLabel { get; set; } = new int[] { -1, -1, -1, -1, -1, -1 };
	[Parameter] public int[] MediaWidthTextBox { get; set; } = new int[] { -1, -1, -1, -1, -1, -1 };
	[Parameter] public TextAlignmentEnum[] MediaLabelAlignment { get; set; } = 
		new TextAlignmentEnum[] { TextAlignmentEnum.Empty, TextAlignmentEnum.Empty, TextAlignmentEnum.Empty, TextAlignmentEnum.Empty, TextAlignmentEnum.Empty, TextAlignmentEnum.Empty };

	[Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object> AdditionalAttributes { get; set; } = new Dictionary<string, object>();


}
