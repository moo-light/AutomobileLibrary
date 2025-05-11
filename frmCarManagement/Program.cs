using log4net;
using log4net.Config;
// Useful help: https://tuanphamdg.wordpress.com/2015/01/01/log4net-trong-c-va-tam-quan-trong-cua-viec-tao-log-nhat-ky-lam-viec/
[assembly: XmlConfigurator(ConfigFile = "UsingLog4Net.xml", Watch = true)]

namespace frmCarManagement
{
    internal static class Program
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(Program));

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.WriteLine("SystemStarted");
            // var configFile = new FileInfo("UsingLog4Net.xml");
            // XmlConfigurator.Configure(configFile);
            _log.Info("Logger started");
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new frmCarManagement());
        }
    }
}