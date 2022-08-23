using BlazorBootstrapComponents.Enums;
using Microsoft.AspNetCore.Components;

namespace BlazorBootstrapComponents.Components;

public partial class IIImages
{
	protected override void OnInitialized()
	{
		if (Src.Length == 0) throw new Exception("A source must be supplied!");
		base.OnInitialized();
	}
	[Parameter] public string Class { get; set; } = string.Empty;
	[Parameter] public TextAlignmentEnum Alignment { get; set; } = TextAlignmentEnum.Empty;
	[Parameter] public bool Responsive { get; set; }
	[Parameter] public bool Thumbnail { get; set; }
	[Parameter] public string Src { get; set; } = string.Empty;
	[Parameter] public string Alt { get; set; } = string.Empty;


	private Dictionary<string, object> AdditionalAttributes { get; set; } = new Dictionary<string, object>();

}
