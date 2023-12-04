namespace WebApp.Client.Shared;

public partial class MainLayout
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
