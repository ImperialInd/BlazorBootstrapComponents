using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorBootstrapComponents.Components;

public partial class BSForm<TModel>
{
	protected override void OnInitialized()
	{
		if(OnSubmitCallback.HasDelegate && (OnValidSubmitCallback.HasDelegate || OnInvalidSubmitCallback.HasDelegate))
		{
			throw new Exception("You can only supply OnSubmitCallback or OnValidSubmitCallback and/or OnInvalidSubmitCallback");
		}
		base.OnInitialized();
	}

	[Parameter] public TModel Model { get; set; }
	[Parameter] public RenderFragment<TModel> ChildContent { get; set; }
	[Parameter] public RenderFragment<TModel> FormActions { get; set; }
	[Parameter] public bool DataAnnotationsValidator { get; set; }
	[Parameter] public bool ValidationSummary { get; set; }
	[Parameter] public bool ShowValidationSummary { get; set; }

	[Parameter] public EventCallback<EditContext> OnSubmitCallback { get; set; }
	[Parameter] public EventCallback<EditContext> OnInvalidSubmitCallback { get; set; }
	[Parameter] public EventCallback<EditContext> OnValidSubmitCallback { get; set; }

	private async Task OnSubmitHandler(EditContext editContext)
	{
		await OnSubmitCallback.InvokeAsync(editContext);
	}
	private async Task OnInvalidSubmitHandler(EditContext editContext)
	{
		await OnInvalidSubmitCallback.InvokeAsync(editContext);
	}
	private async Task OnValidSubmitHandler(EditContext editContext)
	{
		await OnValidSubmitCallback.InvokeAsync(editContext);
	}
}
