using PorterInNet.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorterInNet.Services
{
    public class DefaultFileSystemService : IFileSystemService
    {
        #region Thread-Safe Singleton

        private DefaultFileSystemService() { }
        static DefaultFileSystemService() { }

        private static readonly DefaultFileSystemService instance = new DefaultFileSystemService();

        public static DefaultFileSystemService Instance => instance;

        #endregion

        #region Methods

        public string PathCombine(params string[] paths)
        {
            var arguments = new List<string> { AppDomain.CurrentDomain.BaseDirectory };
            arguments.AddRange(paths);

            return Path.Combine(arguments.ToArray());
        }

        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }

        #endregion

    }
}
