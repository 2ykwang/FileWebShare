using System;
using System.Collections.Specialized;
using System.Web;

namespace FileWebShare
{
	public abstract class HttpParameter : System.Collections.DictionaryBase
	{ 

		public virtual System.Collections.ICollection Keys { get { return Dictionary.Keys; } }
		public virtual System.Collections.ICollection Values { get { return Dictionary.Values; } }

		public  string this[string key]
		{
			get
			{
				if (Dictionary.Contains(key))
				{
					return (string)Dictionary[key];
				}
				else return null;
			}
		}

		public  bool Contains(string key)
		{
			if (key != null)
				return Dictionary.Contains(key);
			else return false;
		}

		public void Add(string headerName, string headerValue)
		{
			if (headerName != null && headerName.Length > 0 && !Contains(headerName) )
			{
				Dictionary.Add(headerName, headerValue);
			}
		}

		public  void Remove(string headerName)
		{
			if (Dictionary.Contains(headerName))
			{
				Dictionary.Remove(headerName);
			}
		}
		public virtual void AddParameterFromQueryString(string query)
		{ 
			if (query != null || query.Length > 0)
			{
				NameValueCollection nvc = HttpUtility.ParseQueryString(query);
				foreach (string key in nvc.AllKeys)
				{
					Add(key, nvc[key]);
				}
			}
		}
	}
}
