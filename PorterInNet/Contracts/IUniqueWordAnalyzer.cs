using PorterInNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorterInNet.Contracts
{
    public interface IUniqueWordAnalyzer
    {
        FullAnalysisResult Analyze(string input);
    }
}
