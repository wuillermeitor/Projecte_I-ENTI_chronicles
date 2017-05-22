using System;
using System.Collections.Generic;


public class GameData
{
	private static GameData _instance = null;

	private Dictionary<String,Object> data = new Dictionary<String,Object> ();

	private GameData ()
	{
	}

	public static GameData GetInstance() {
		if (_instance == null)
			_instance = new GameData ();

		return _instance;
	}

	public void AddValue(String key, Object value) {
		data.Add (key, value);
	}

	public Object GetValue(String key) {
		return data [key];
	}
}


