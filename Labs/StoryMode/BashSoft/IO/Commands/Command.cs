namespace BashSoft.IO.Commands
{
    using Exceptions;
    using Judge;
    using Network;
    using Repository;
    using System;

    public abstract class Command
    {
        private string input;
        private string[] data;

        private Tester judge;
        private StudentsRepository repository;
        private DownloadManager downloadManager;
        private IOManager ioManager;

        public Command(
            string input,
            string[] data,
            Tester judge,
            StudentsRepository repository,
            DownloadManager downloadManager,
            IOManager ioManager)
        {
            this.Input = input;
            this.Data = data;
            this.repository = repository;
            this.judge = judge;
            this.downloadManager = downloadManager;
            this.ioManager = ioManager;
        }

        protected string Input
        {
            get { return this.input; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.input = value;
            }
        }

        protected string[] Data
        {
            get { return this.data; }

            set
            {
                if (value == null || value.Length == 0)
                {
                    throw new NullReferenceException();
                }

                this.data = value;
            }
        }

        protected StudentsRepository Repository => this.repository;

        protected Tester Judge => this.judge;

        protected IOManager IOManager => this.ioManager;

        protected DownloadManager DownloadManager => this.downloadManager;

        public abstract void Execute();
    }
}