using CrashKonijn.Agent.Core;
using CrashKonijn.Goap.Core;
using CrashKonijn.Goap.Runtime;
using Rim_World.Behaviours;
using Rim_World.Interfaces;

namespace Rim_World.Sensors.World
{
    public class BlueprintSensor<T> : LocalWorldSensorBase, IInjectable where T : IBlueprint
    {
        private ItemBlueprintManager blueprintManager;
        
        public void Inject(GoapInjectorBehaviour injector)
        {
            this.blueprintManager = injector.itemBlueprintManager;
        }

        public override void Created()
        {
        }

        public override void Update()
        {
        }

        public override SenseValue Sense(IActionReceiver agent, IComponentReference references)
        {
            var count = this.blueprintManager.Filtered<T>().Length;
            return count;
        }
    }
}
