namespace Executor.Network
{
    using System.Net;
    using System.Threading.Tasks;
    using Contracts;
    using Exceptions;
    using IO;
    using Static_data;

    public class DownloadManager : IDownloadManager
    {
        private WebClient webClient;

        public DownloadManager()
        {
            this.webClient = new WebClient();
        }

        public void Download(string fileUrl)
        {
            try
            {
                OutputWriter.WriteMessageOnNewLine("Started downloading: ");

                string nameOfFile = this.ExtractNameOfFile(fileUrl);
                string pathToDownload = SessionData.currentPath + "/" + nameOfFile;

                this.webClient.DownloadFile(fileUrl, pathToDownload);

                OutputWriter.WriteMessageOnNewLine("Download complete");
            }
            catch (WebException)
            {
                throw new InvalidPathException();
            }

        }

        public void DownloadAsync(string fileUrl)
        {
            Task currentTask = Task.Run(() => this.Download(fileUrl));
            SessionData.taskPool.Add(currentTask);
        }

        private string ExtractNameOfFile(string fileURL)
        {
            int indexOfLastBackSlash = fileURL.LastIndexOf("/");

            if (indexOfLastBackSlash != -1)
            {
                return fileURL.Substring(indexOfLastBackSlash + 1);
            }
            else
            {
                throw new InvalidPathException();
            }
        }
    }
}
