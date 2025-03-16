using CrashKonijn.Goap.Core;
using CrashKonijn.Goap.Runtime;
using Rim_World.Actions;
using Rim_World.GameItems;
using Rim_World.GameSources;
using Rim_World.Goals;
using Rim_World.Sensors.Target;
using Rim_World.Sensors.World;
using Rim_World.Targets;
using Rim_World.WorldKeys;

namespace Rim_World.AgentTypes
{
    public class WoodWorkerAgentTypeConfigFactory : AgentTypeFactoryBase
    {
        public override IAgentTypeConfig Create()
        {
            var builder = new AgentTypeBuilder("WoodWorker");

            builder.CreateCapability("WoodWorkerCapability", (capability) =>
            {
                // Goal: 制作箱子
                capability.AddGoal<CreateItemGoal<Box>>()
                    .AddCondition<CreatedItem<Box>>(Comparison.GreaterThanOrEqual, 1);

                // Action: 制作箱子
                capability.AddAction<CreateItemAction<Box>>()
                    // Target: 最近的工作台
                    .SetTarget<ClosestTarget<WorkbenchSource>>()
                    // Effect: 箱子数量增加
                    .AddEffect<CreatedItem<Box>>(EffectType.Increase)
                    // Properties: 10个木头 => 1个箱子
                    .SetProperties(new CreateItemAction<Box>.Props()
                    {
                        requiredWood = 10,
                    })
                    // Condition: Agent手持木头数量大于等于10
                    .AddCondition<IsHolding<Wood>>(Comparison.GreaterThanOrEqual, 10);

                // Sensor: 最近的工作台
                capability.AddTargetSensor<ClosestObjectSensor<WorkbenchSource>>()
                    // Target: 最近的工作台
                    .SetTarget<ClosestTarget<WorkbenchSource>>();
                
                // Sensor: Agent手持木头的数量
                capability.AddWorldSensor<IsHoldingSensor<Wood>>()
                    .SetKey<IsHolding<Wood>>();
            });
            
            return builder.Build();
        }
    }
}
