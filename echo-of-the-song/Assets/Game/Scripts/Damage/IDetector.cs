using Mechanics.Damage;
using System.Collections.Generic;

namespace Mechanics.DetectorCollision
{
    public interface IDetector
    {
        public DetectionData Detect();
    }
}
