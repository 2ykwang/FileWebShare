using System;
namespace FileWebShare.Server
{
	public class ServerSetting
	{
		/// <summary>
		/// Gets or sets the port.
		/// </summary>
		/// <value>The port.</value>
		public int Port { get; set; }

		/// <summary>
		/// Gets or sets the IPA ddress.
		/// </summary>
		/// <value>The IPA ddress.</value>
		public System.Net.IPAddress IPAddress { get; set; }

		/// <summary>
		/// Gets or sets the default controller.
		/// </summary>
		/// <value>The default controller.</value>
		public string DefaultController { get; set; }

		/// <summary>
		/// Gets or sets the default method.
		/// </summary>
		/// <value>The default method.</value>
		public string DefaultMethod { get; set; }
	}
}
