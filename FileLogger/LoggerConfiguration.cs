using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLogger
{
    public class LoggerConfiguration
    {
        private string _fileLocation;
        private LoggingType _loggingType;

        public LoggerConfiguration(string fileLocation, LoggingType loggingType, bool logToCurrentDirectory = true)
        {
            if (logToCurrentDirectory)
            {
                this._fileLocation = Path.Combine(Environment.CurrentDirectory, fileLocation);
            }
            else
            {
                this._fileLocation = fileLocation;
            }

            this._loggingType = loggingType;

            if (loggingType == LoggingType.File)
            {
                if(!fileLocation.EndsWith(".txt"))
                {
                    WriteToBaseFile("The logger only supports .txt files.");
                    return;
                }

                if(this.TryCreateFile())
                {
                    WriteToBaseFile("File created successfully.");
                }
                else
                {
                    WriteToBaseFile("Could not create file at path.");
                }
            }
        }

        /// <summary>
        /// Writes to base file in current directory
        /// </summary>
        /// <param name="message"></param>
        public void WriteToBaseFile(string message)
        {
            string baseLocation = Path.Combine(Environment.CurrentDirectory, "basefile.txt");

            if (!File.Exists(baseLocation))
            {
                using (FileStream fileStream = new FileStream(baseLocation, FileMode.Create))
                {

                }
            }

            using (var writer = new StreamWriter(baseLocation, true))
            {
                writer.WriteLine("[" + DateTime.Now + "] [INF] " + message);
            }
        }

        /// <summary>
        /// Creates a streamwriter
        /// </summary>
        /// <returns>Streamwriter based on given path</returns>
        public StreamWriter GetStreamWriter()
        {
            return new StreamWriter(this._fileLocation, true);
        }


        /// <summary>
        /// Tries to create file based on given path if file does not exists
        /// </summary>
        /// <returns></returns>
        private bool TryCreateFile()
        {
            if (this.PathExists())
            {
                return true;
            }

            try
            {
                if (!File.Exists(this._fileLocation))
                {
                    using (FileStream fileStream = new FileStream(this._fileLocation, FileMode.Create))
                    {

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if given path exists
        /// </summary>
        /// <returns></returns>
        public bool PathExists()
        {
            if (File.Exists(this._fileLocation))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// File Location
        /// </summary>
        public string FileLocation
        {
            get
            {
                return this._fileLocation;
            }
        }
    }
}
