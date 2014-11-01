using System;
using System.IO;

namespace CleanCode
{
	public static class RefactorMethod
	{
		private static void SaveData(string fileName, byte[] data)
		{
			//open files
			var fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
			var backupStream = new FileStream(Path.ChangeExtension(fileName, "bkp"), FileMode.OpenOrCreate);

			// write data
			fileStream.Write(data, 0, data.Length);
			backupStream.Write(data, 0, data.Length);

			// close files
			fileStream.Close();
			backupStream.Close();

			// save last-write time
			string tf = fileName + ".time";
			var dateFileStream = new FileStream(tf, FileMode.OpenOrCreate);
			var t = BitConverter.GetBytes(DateTime.Now.Ticks);
			dateFileStream.Write(t, 0, t.Length);
			dateFileStream.Close();
		}
	}
}