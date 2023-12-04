namespace WebApp.Client.Configuration.Extensions;

public static class CommonExtensions
{
	public static string WithDefault(this string value, string defaultValue)
	{
		return string.IsNullOrEmpty(value) ? defaultValue : value;
	}

	//public static string WithDefault(this string value, string defaultValue)
	//{
	//	return string.IsNullOrEmpty(value) ? defaultValue : value;
	//}
}
