using Microsoft.AspNetCore.Components;
using Telerik.Blazor;
using Telerik.FontIcons;

namespace WebApp.Client.Shared.Controls;

public partial class Button
{
	[Parameter]
	public Action OnClick { get; set; }

	[Parameter]
	public string Text { get; set; }

	[Parameter]
	public string CssClass { get; set; }

	[Parameter]
	public string Tooltip { get; set; }

	[Parameter]
	public string TooltipCssClass { get; set; }

	[Parameter]
	public FontIcon Icon { get; set; }

	[Parameter]
	public string TextClass { get; set; }

	[Parameter]
	public string FillMode { get; set; } = ThemeConstants.Button.FillMode.Outline;

	[Parameter]
	public bool Disabled { get; set; }

	[Parameter]
	public string Color { get; set; } = ThemeConstants.Button.ThemeColor.Primary;

	[Parameter]
	public string Size { get; set; } = ThemeConstants.Button.Size.Medium;
}
