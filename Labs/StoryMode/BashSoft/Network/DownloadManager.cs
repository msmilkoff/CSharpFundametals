namespace BashSoft.Network
{
    using System.Net;
    using System.Threading.Tasks;
    using Exceptions;
    using IO;
    using Static_Data;

    public class DownloadManager
    {
        private WebClient webClient;

        public DownloadManager()
        {
            this.webClient = new WebClient();
        }

        public void Download(string fileUrl)
        {
            var webClient = new WebClient();

            try
            {
                OutputWriter.WriteMessageOnNewLine("Started downloading...");

                string fileName = ExtractNameOfFile(fileUrl);
                string downloadPath = SessionData.currentPath + "/" + fileName;

                webClient.DownloadFile(fileUrl, downloadPath);

                OutputWriter.WriteMessageOnNewLine("Download complete.");
            }
            catch (WebException ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        }

        public void DownloadAsync(string fileUrl)
        {
            Task.Run(() => Download(fileUrl));
        }

        private string ExtractNameOfFile(string fileUrl)
        {
            int indexOfLastSlash = fileUrl.LastIndexOf('/');
            if (indexOfLastSlash != -1)
            {
                return fileUrl.Substring(indexOfLastSlash + 1);
            }
            else
            {
                throw new WebException(InvalidPathException.InvalidPath);
            }
        }
    }
}