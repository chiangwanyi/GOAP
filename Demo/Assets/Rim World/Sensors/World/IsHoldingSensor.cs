using CrashKonijn.Agent.Core;
using CrashKonijn.Goap.Core;
using CrashKonijn.Goap.Runtime;
using Rim_World.Behaviours;
using Rim_World.Interfaces;

namespace Rim_World.Sensors.World
{
    public class IsHoldingSensor<T> : LocalWorldSensorBase where T : IHoldable
    {
        public override void Created()
        {
        }

        public override void Update()
        {
        }

        public override SenseValue Sense(IActionReceiver agent, IComponentReference references)
        {
            var inventory = references.GetCachedComponent<AgentInventoryBehaviour>();
            
            if (!inventory)
                return false;
            
            return inventory.Count<T>();
        }
    }
}
