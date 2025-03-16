using System;
using CrashKonijn.Agent.Core;
using CrashKonijn.Goap.Runtime;
using Rim_World.Behaviours;
using Rim_World.Interfaces;

namespace Rim_World.Sensors.Target
{
    public class ClosestBlueprintSensor<T> : LocalTargetSensorBase, IInjectable where T : IBlueprint
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
            var blueprint = this.blueprintManager.Closest<T>(agent.Transform.position);
            
            if (blueprint is null)
                return default;
            
            var inventory = references.GetCachedComponent<AgentInventoryBehaviour>();
            blueprint.agentName = inventory.agentName;
            
            if (existingTarget is TransformTarget targetTransform)
                return targetTransform.SetTransform(blueprint.transform);
                
            return new TransformTarget(blueprint.transform);
        }
    }
}
