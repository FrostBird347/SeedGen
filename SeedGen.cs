using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SeedGen
{
	public static class Main
	{
		private static int LastSeed = 0;

		public static int GenSeed()
		{
			int Seed = GenHash(Environment.MachineName + Environment.OSVersion.VersionString + Environment.ProcessorCount.ToString() + Environment.TickCount.ToString() + Environment.UserName + LastSeed.ToString());
			return Seed;
		}

		private static int GenHash(string Input)
		{
			using (MD5 md5 = MD5.Create())
			{
				md5.Initialize();
				byte[] InputBytes = Encoding.ASCII.GetBytes(Input);
				byte[] HashBytes = md5.ComputeHash(InputBytes);
				int HashInt = BitConverter.ToInt32(HashBytes, 0);
				LastSeed = HashInt;
				return HashInt;
			}
		}
	}
}
