namespace FileCreator
{
    internal class AppSettings
    {
        public string DestinationFilePath { get; set; }
        public int DestinationFileSize { get; set; } // MB
        public bool ShowProgress { get; set; } //Show progress while creating a large file.
        public string[] Template { get; set; }
        public int MaxNumber { get; set; }

    }
}
