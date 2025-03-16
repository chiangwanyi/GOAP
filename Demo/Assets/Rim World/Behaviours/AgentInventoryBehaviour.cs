using System.Collections.Generic;
using System.Linq;
using Rim_World.Game.Items;
using Rim_World.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace Rim_World.Behaviours
{
    public class AgentInventoryBehaviour : MonoBehaviour
    {
        public string agentName;
        public int woodCount;
        
        public void Remove<T>(int count)
            where T : IHoldable
        {
            if (typeof(T) == typeof(Wood) && this.woodCount >= count)
            {
                this.woodCount -= count;
            } 
        }
        
        public int Count<T>() where T : IHoldable
        {
            if (typeof(T) == typeof(Wood))
            {
                return this.woodCount;
            }
            return 0;
        }
    }
}
