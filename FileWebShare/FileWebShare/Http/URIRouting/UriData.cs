using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FileWebShare
{
	enum SegmentWhere
	{
		Leading,
		Traiing,
		Both
	}
	public class UriData : Uri
	{
		private string _slicePath;

		public UriData(string uriString) : base(uriString)
		{
			_slicePath = PathAndQuery.Remove(0, 1);  
		}
		 
		public string GetSegment(int number)
		{ 
			string[] query = _slicePath.Split('/'); 

			return (query.Length > 0 && number < query.Length) ? query[number] : string.Empty;
		}
		public int GetSegmentCount()
		{
			return _slicePath.Split('/').Length;
		}
		/*
		public string GetSlashSegment(int number, SegmentWhere where = SegmentWhere.Traiing)
		{
			
		}
		public string[] UriToArray(int offset = 3)
		{

		} 
		*/
	}
}
