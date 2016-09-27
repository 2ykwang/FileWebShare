using System;
using System.Net;


namespace FileWebShare
{
	public class Request
	{
		#region Property

		/// <summary>
		/// 클라이언트 요청 메소드
		/// </summary>
		public string Method { get; set; }

		/// <summary>
		/// 클라이언트 요청 헤더 컬렉션
		/// </summary>
		public HeaderCollection HeaderCollection { get; private set; }

		/// <summary>
		/// 클라이언트 요청 Body
		/// </summary>
		public string Body { get; set; }

		/// <summary>
		/// Gets the URI.
		/// </summary>
		/// <value>The URI.</value>
		public Uri Uri { get; set; }

		/// <summary>
		/// 클라이언트 IPv4 주소
		/// </summary>
		public IPAddress IPAddress { get; set; }
		
		/// <summary>
		/// HTTP 버전
		/// </summary>
		public string HTTPVersion { get; set; }

		#endregion

		public Request()
		{
			HeaderCollection = new HeaderCollection();
		}
	}
}
