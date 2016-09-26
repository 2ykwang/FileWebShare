using System;
using System.Net;
using System.Net.Sockets; 
using System.Threading.Tasks;
using System.IO; 
namespace FileWebShare.Server
{
	public abstract class Server
	{
		//Thread 
		private Task _taskListen;
		private Task _taskAccept;
		 

		public virtual ServerSetting ServerSetting { get; protected set; }
		private TcpListener _tcpListener;

		public bool Started { get; private set; }

		public Server(ServerSetting serverSetting)
		{
			ServerSetting = ServerSetting;
			Started = false;
		}

		public bool Start()
		{
			if(ServerSetting.IPAdress == null)
				throw new Exception("IPAdress가 NULL 값 입니다. ");
			if ( ServerSetting.Port == 0)
				throw new Exception("포트가 지정되어 있지 않습니다.");

			_taskListen = Task.Run(() => ListenThread(ServerSetting.IPAdress, ServerSetting.Port));
			return true;
		}
		private async Task ListenThread(IPAddress ipAddress, int port) // 클라이언트 수신부분
		{
			_tcpListener = new TcpListener(ipAddress, port);
			_tcpListener.Start();
			  
			while (Started) // Accept 이 곳에서 클라이언트 접속을 받는다. _start 변수값으로 Loop
			{
				try
				{
					TcpClient tcpClient = await _tcpListener.AcceptTcpClientAsync();
					_taskAccept = Task.Run(() => AcceptHandle(tcpClient));
				}
				catch (SocketException e)
				{
					Console.WriteLine(e.ToString());
				}
			}
		}

		private async Task AcceptHandle(TcpClient tcpClient) //클라이언트 접속 처리 부분
		{
			if (tcpClient.Connected) // 클라이언트가 접속중일 경우
			{ 
			}
		}
	}
}
