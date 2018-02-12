using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorterInNet.Services
{
    public class EnvironmentConfiguration
    {
        #region Thread-Safe Singleton
        
        private EnvironmentConfiguration() { }
        static EnvironmentConfiguration() { }

        private static readonly EnvironmentConfiguration instance = new EnvironmentConfiguration();

        public static EnvironmentConfiguration Instance => instance;

        #endregion

        #region Properties

        public string DefaultInputFile => DefaultFileSystemService.Instance.PathCombine(AppDomain.CurrentDomain.BaseDirectory,  ConfigurationManager.AppSettings["DefaultInputFile"]);

        public bool DefaultInputFileExists => DefaultFileSystemService.Instance.FileExists(DefaultInputFile);

        #endregion
    }
}
