using System.Text;


namespace FileCreator
{
    internal class Creator(AppSettings appSettings)
    {
        private readonly AppSettings _appSettings = appSettings;

        public void CreateFile()
        {
            long fileSizeInBytes = 1048576 * Convert.ToInt64(_appSettings.DestinationFileSize);
            long fileSize = 0;

            using (StreamWriter writer = new StreamWriter(_appSettings.DestinationFilePath))
            {
                Random random = new Random();
                int lastPercent = 0;
                while (fileSize < fileSizeInBytes)
                {
                    var row = $"{random.Next(1, _appSettings.MaxNumber)}. {_appSettings.Template[random.Next(0, _appSettings.Template.Length)]}";
                    writer.WriteLine(row);

                    fileSize += Encoding.UTF8.GetByteCount(row + Environment.NewLine);

                    if (_appSettings.ShowProgress)
                    {
                        int percent = (int)(fileSize * 100 / fileSizeInBytes);

                        if (percent > lastPercent)
                        {
                            lastPercent = percent;
                            Console.Write($"\rProgress: {percent}%");
                        }
                    }
                }
            }

            Console.WriteLine($"\nFile created: {_appSettings.DestinationFilePath}");
        }
    }
}
