using System;

namespace FileWebShare
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

		/// <summary>
		/// Gets or sets the controller trigger.
		/// </summary>
		/// <value>The controller trigger.</value>
		public string ControllerTrigger { get; set; }

		/// <summary>
		/// Gets or sets the method trigger.
		/// </summary>
		/// <value>The method trigger.</value>
		public string MethodTrigger { get; set; }

		/// <summary>
		/// Route List 값을 정하거나 가져옵니다.
		/// </summary>
		/// <value>The Route list.</value>
		public RouteList RouteList { get; set; }
	}
}
