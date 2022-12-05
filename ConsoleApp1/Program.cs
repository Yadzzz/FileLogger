













using FileLogger;

LoggerConfiguration LoggerConfiguration = new LoggerConfiguration(@"\test.txt", LoggingType.File);
FileLogger.FileLogger FileLogger = new FileLogger.FileLogger(LoggerConfiguration);
FileLogger.Log("testsad asd asd sad asd");
FileLogger.LogWarning("kasdk");
FileLogger.LogError("kaskdkdas");




Console.ReadKey();