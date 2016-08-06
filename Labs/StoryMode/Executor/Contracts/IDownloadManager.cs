namespace Executor.Contracts
{
    public interface IDownloadManager
    {
        void Download(string fileUrl);

        void DownloadAsync(string fileUrl);
    }
}