using System;
using System.Net;

using FileWebShare.Collection;


namespace FileWebShare.Request
{
	public class Request
	{
		#region Property

		/// <summary>
		/// 클라이언트 요청 메소드
		/// </summary>
		public string Method { get; private set; }

		/// <summary>
		/// 클라이언트 요청 헤더 컬렉션
		/// </summary>
		public HeaderCollection HeaderCollection { get; private set; }

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
		}
	}
}
