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

        public LoggerConfiguration(string fileLocation, LoggingType loggingType)
        {
            this._fileLocation = Environment.CurrentDirectory +  @"\" + fileLocation;
            this._loggingType = loggingType;

            if (loggingType == LoggingType.File)
            {
                if(!fileLocation.EndsWith(".txt"))
                {
                    Console.WriteLine("The logger only supports .txt files.");
                    return;
                }

                if(this.TryCreateFile())
                {
                    Console.WriteLine("File created successfully.");
                }
                else
                {
                    Console.WriteLine("Could not create file at path.");
                }
            }
        }

        public StreamWriter GetStreamWriter()
        {
            return new StreamWriter(this._fileLocation, true);
        }

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

        public bool PathExists()
        {
            if (File.Exists(this._fileLocation))
            {
                return true;
            }

            return false;
        }

        public string FileLocation
        {
            get
            {
                return this._fileLocation;
            }
        }
    }
}
