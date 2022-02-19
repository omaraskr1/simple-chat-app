using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace clint
{
	class Program
	{
		
		static void Main(string[] args)
		{
			





			IPAddress host = IPAddress.Parse("127.0.0.1");
			
			IPEndPoint hostEndpoint = new IPEndPoint(host, 8000);
			

			Socket clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

			clientSock.Connect(hostEndpoint);
		
			
				Console.WriteLine("getting file....");
				byte[] clientData = new byte[1024];
				int receivedBytesLen = clientSock.Receive(clientData);
				int fileNameLen = BitConverter.ToInt32(clientData, 0);
				string fileName = Encoding.ASCII.GetString(clientData, 4, fileNameLen);
				BinaryWriter bWrite = new BinaryWriter(File.Open(fileName, FileMode.Create));
				bWrite.Write(clientData, 4 + fileNameLen, receivedBytesLen - 4 - fileNameLen);
				bWrite.Close();
				
			

			
			Console.WriteLine("Conversation Ended");
			clientSock.Shutdown(SocketShutdown.Both);
			clientSock.Close();

			Console.WriteLine("Hello World!");
		}
	}
}
