using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Technology.VoIP
{
   public class LogFactory
    {
        public const string ConfigFileName = "voiplog.config";
        public static ILog GetLogger(Type type)
        {
            String strAppDir = Path.GetDirectoryName(
             Assembly.GetExecutingAssembly().GetName().FullName);
            strAppDir = AppDomain.CurrentDomain.BaseDirectory;
            if (Uri.IsWellFormedUriString(strAppDir, UriKind.RelativeOrAbsolute))
            {
                strAppDir = new Uri(Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().GetName().CodeBase)).LocalPath;
            }
            string path = Path.Combine(strAppDir, ConfigFileName);
            FileInfo configFile = new FileInfo(path);
            XmlConfigurator.ConfigureAndWatch(configFile);
            log4net.ILog log = LogManager.GetLogger(type);
            return log;
        }       
    }
}
