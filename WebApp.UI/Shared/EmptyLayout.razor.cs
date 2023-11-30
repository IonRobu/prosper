namespace WebApp.UI.Shared;

public partial class EmptyLayout
{
	private bool IsLoaded { get; set; }

	protected override void OnInitialized()
	{
		IsLoaded = true;
		base.OnInitialized();
	}

	public void Dispose()
	{
		IsLoaded = false;
	}
}
