using Mechanics.Damage;
using System.Collections.Generic;

namespace Mechanics.Detection
{
    public interface IDetector
    {
        public IEnumerable<DetectionData> Detect();
    }
}
