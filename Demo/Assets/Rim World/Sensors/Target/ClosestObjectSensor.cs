using System.Linq;
using CrashKonijn.Agent.Core;
using CrashKonijn.Goap.Runtime;
using UnityEngine;

namespace Rim_World.Sensors.Target
{
    public class ClosestObjectSensor<T> : LocalTargetSensorBase where T : MonoBehaviour
    {
        private T[] items;
        
        public override void Created()
        {
        }

        public override void Update()
        {
            this.items = (T[]) Object.FindObjectsOfType(typeof (T));
        }

        public override ITarget Sense(IActionReceiver agent, IComponentReference references, ITarget existingTarget)
        {
            var closestItem = this.items.OrderBy(x => Vector3.Distance(x.transform.position, agent.Transform.position))
                .FirstOrDefault();
            
            if (!closestItem)
                return null;
            
            if (existingTarget is TransformTarget transformTarget)
                return transformTarget.SetTransform(closestItem.transform);
            
            return new TransformTarget(closestItem.transform);
        }
    }
}
