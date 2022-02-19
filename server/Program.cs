using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace server
{
	class Program
	{
		
		static void Main(string[] args)
		{
			

			




			IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
			

			Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

			sock.Bind(ipEnd);

			sock.Listen(100);
			Socket clientSock = sock.Accept();
		
			
			string fileName = "file.txt";// "c:\\filetosend.txt";
			byte[] fileNameByte = Encoding.ASCII.GetBytes(fileName);
			byte[] fileNameLen = BitConverter.GetBytes(fileNameByte.Length);
			byte[] fileData = File.ReadAllBytes(fileName);
			byte[] serverData = new byte[4 + fileNameByte.Length + fileData.Length];
			fileNameLen.CopyTo(serverData, 0);
			fileNameByte.CopyTo(serverData, 4);
			fileData.CopyTo(serverData, 4 + fileNameByte.Length);
			clientSock.Send(serverData);
			
			clientSock.Shutdown(SocketShutdown.Both);
			clientSock.Close();
			Console.WriteLine(fileName);
			Console.WriteLine("omar khaled nasr askr");
			Console.WriteLine("is");
			Console.WriteLine("section 6");
			Console.WriteLine("listening at ip: " +ipEnd.Address +" ,port: "+ipEnd.Port);
			Console.WriteLine("clinet accepted");
			Console.WriteLine("sending file: "+fileName);
			Console.WriteLine("file sent ");


		}
	}
}
