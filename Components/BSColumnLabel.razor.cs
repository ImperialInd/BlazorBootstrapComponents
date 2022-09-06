using BlazorBootstrapComponents.Enums;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBootstrapComponents.Components;

public partial class BSColumnLabel
{
	protected override void OnInitialized()
	{
		if (For == string.Empty) throw new Exception("You must supply the [For] id of the control this label belongs to!");

		AdditionalAttributes.Remove("for");
		AdditionalAttributes.Add("for", @For);

		base.OnInitialized();
	}
	[Parameter]
	public TextAlignmentEnum[] MediaAlignment { get; set; } =
		new TextAlignmentEnum[] { TextAlignmentEnum.Empty, TextAlignmentEnum.Empty, TextAlignmentEnum.Empty, TextAlignmentEnum.Empty, TextAlignmentEnum.Empty, TextAlignmentEnum.Empty };
	[Parameter] public bool Bold { get; set; }
	[Parameter] public string For { get; set; } = string.Empty;
	[Parameter] public FontSizeEnum FontSize { get; set; } = FontSizeEnum.Empty;
	[Parameter] public TextColorEnum Color { get; set; } = TextColorEnum.Empty;
	[Parameter] public ControlSizeEnum Size { get; set; } = ControlSizeEnum.Standard;
	[Parameter] public RenderFragment ChildContent { get; set; }
	[Parameter] public int[] MediaWidth { get; set; } = new int[] { -1, -1, -1, -1, -1, -1 };

	private Dictionary<string, object> AdditionalAttributes { get; set; } = new Dictionary<string, object>();

	private string GenerateWidth()
	{
		string output = String.Empty;

		if (MediaWidth[0] == 0) output += $"col ";
		if (MediaWidth[0] > 0) output += $"col-{MediaWidth[0]} ";
		if (MediaWidth[1] == 0) output += $"col-sm ";
		if (MediaWidth[1] > 0) output += $"col-sm-{MediaWidth[1]} ";
		if (MediaWidth[2] == 0) output += $"col-md ";
		if (MediaWidth[2] > 0) output += $"col-md-{MediaWidth[2]} ";
		if (MediaWidth[3] == 0) output += $"col-lg ";
		if (MediaWidth[3] > 0) output += $"col-lg-{MediaWidth[3]} ";
		if (MediaWidth[4] == 0) output += $"col-xl ";
		if (MediaWidth[4] > 0) output += $"col-xl-{MediaWidth[4]} ";
		if (MediaWidth[5] == 0) output += $"col-xxl ";
		if (MediaWidth[5] > 0) output += $"col-xxl-{MediaWidth[5]} ";

		if (output.Length == 0) output = "col ";
		return output;

	}

}
