using System;
namespace FileWebShare
{
	public abstract class Controller : iController
	{
		public Client Client { get;  private set; }

		public void Initialize(Client client)
		{
			Client = client;
		}
		public abstract void Index();
	}
}
