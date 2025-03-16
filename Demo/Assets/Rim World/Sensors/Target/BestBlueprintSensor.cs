using CrashKonijn.Agent.Core;
using CrashKonijn.Goap.Runtime;
using Rim_World.Behaviours;
using Rim_World.Interfaces;

namespace Rim_World.Sensors.Target
{
    public class BestBlueprintSensor<T> : LocalTargetSensorBase, IInjectable where T : IBlueprint
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

        public override ITarget Sense(IActionReceiver agent, IComponentReference references, ITarget existingTarget)
        {
            var inventory = references.GetCachedComponent<AgentInventoryBehaviour>();
            var agentName = inventory.agentName;
            var blueprint = this.blueprintManager.GetByAgentName<T>(agentName);
            if (!blueprint)
            {
                blueprint = this.blueprintManager.Closest<T>(agent.Transform.position);
            }
            if (blueprint is null)
                return default;
            this.blueprintManager.TakenBlueprint<T>(blueprint, agentName);
            
            if (existingTarget is TransformTarget targetTransform)
                return targetTransform.SetTransform(blueprint.transform);
                
            return new TransformTarget(blueprint.transform);
        }
    }
}
