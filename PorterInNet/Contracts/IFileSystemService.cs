using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorterInNet.Contracts
{
    public interface IFileSystemService
    {
        string PathCombine(params string[] paths);
        bool FileExists(string path);
        string ReadAllText(string path);
    }
}
