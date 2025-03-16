using CrashKonijn.Agent.Core;
using CrashKonijn.Goap.Runtime;
using UnityEngine;

namespace Rim_World.Sensors.Target
{
    public class ClosestObjectSensor<T> : LocalTargetSensorBase where T : MonoBehaviour
    {
        public override void Created()
        {
        }

        public override void Update()
        {
        }

        public override ITarget Sense(IActionReceiver agent, IComponentReference references, ITarget existingTarget)
        {
            throw new System.NotImplementedException();
        }
    }
}
