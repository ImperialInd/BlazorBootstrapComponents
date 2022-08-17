using Microsoft.AspNetCore.Components;

namespace BlazorBootstrapComponents.Components.Forms;

public partial class Form<TModel>
{
	[Parameter] public TModel Model { get; set; }
	[Parameter] public RenderFragment<TModel> ChildContent { get; set; }
	[Parameter] public RenderFragment<TModel> FormActions { get; set; }
}
