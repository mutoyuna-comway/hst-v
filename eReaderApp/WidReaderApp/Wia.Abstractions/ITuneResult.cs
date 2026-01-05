using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wia.Abstractions
{
    public interface ITuneResult
    {
        MarkType Mark { get; }
        double Progress { get; }
        int NumRead { get; }
        bool CurrentPassed { get; }
        string CurrentString { get; }
        double CurrentScore { get; }
        bool BestPassed { get; }
        string BestString { get; }
        double BestScore { get; }
        int NumTunePassed { get; }
        int NumTuneFailed { get; }
        double CurrentMinimumScore { get; }
        double BestMinimumScore { get; }

        IJobReadSettings BestRead { get; }

        string GetCurrentString(int fieldStrNum);
        string GetBestString(int fieldStrNum);
    }
}
