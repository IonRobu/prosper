namespace WebApp.Backend.Configuration;

public class SessionState
{
	private static Dictionary<string, object> _items = new();

	public event Action OnChanged;

	public void AddItem(string key, object value)
	{
		_items.Add(key, value);
	}

	public object GetItem(string key, bool remove = true)
	{
		var result = _items.SingleOrDefault(x => x.Key == key);

		if(result.Value == null)
		{
			return default;
		}
		if (remove)
		{
			_items.Remove(key);
		}
		return result.Value;
	}

	public TItem GetItem<TItem>(string key, bool remove = true)
	{
		var result = GetItem(key, remove);
		if (result == null)
		{
			return default;
		}
		return (TItem)result;
	}
}
