using System;
using System.Collections.Generic;
using System.Text;

namespace FileWebShare
{
	public class HeaderCollection : System.Collections.DictionaryBase
	{

		public System.Collections.ICollection Keys { get { return Dictionary.Keys; } }
		public System.Collections.ICollection Values { get { return Dictionary.Values; } }

		public string this[string key]
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

		public bool Contains(string key)
		{
			return Dictionary.Contains(key);
		}

		public void Add(string headerName, string headerValue)
		{
			Dictionary.Add(headerName, headerValue);
		}

		public void Remove(string headerName)
		{
			if (Dictionary.Contains(headerName))
			{
				Dictionary.Remove(headerName);
			}
		}

		/// <summary>
		/// 헤더 컬렉션을 문자열로 변환합니다.
		/// </summary>
		/// <returns>HTTP Header 형태로 반환</returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			foreach (System.Collections.DictionaryEntry entry in Dictionary)
			{
				sb.Append($"{entry.Key}: {entry.Value}{Environment.NewLine}");
			}
			return sb.ToString();
		} 
	}
}
