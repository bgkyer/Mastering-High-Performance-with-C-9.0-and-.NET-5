using System;

namespace CH09_OsiReferenceModel
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			SendMail();
			Console.WriteLine("Email has been sent.");
		}

		static void SendMail()
		{
			EmailServer.SendEmail(
				"jasonalls@hotmail.com"
				, "jasonalls@hotmail.com"
				, "jason.alls@gl-education.com"
				, "alanalls@hotmail.com"
				, "Test Message"
				, "Test Body. You can delete!"
			);
		}
	}
}
