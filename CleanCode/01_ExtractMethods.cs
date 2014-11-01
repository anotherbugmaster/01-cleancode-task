using System;
using System.IO;

namespace CleanCode
{
	public static class RefactorMethod
	{
		private static void SaveData(string fileName, byte[] data)
		{
			//open files
            WriteData(fileName, data);
            WriteData(Path.ChangeExtension(fileName, "bkp"), data);

            string timeFileName = fileName + ".time";
            var ticks = BitConverter.GetBytes(DateTime.Now.Ticks);
            WriteData(timeFileName, ticks);
		}

	    private static void WriteData(string fileName, byte[] data)
	    {
	        var fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
	        fileStream.Write(data, 0, data.Length);
	        fileStream.Close();
	    }
	}
}