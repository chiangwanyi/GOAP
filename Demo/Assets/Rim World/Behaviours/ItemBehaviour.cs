using Rim_World.Interfaces;
using UnityEngine;

namespace Rim_World.Behaviours
{
    public abstract class ItemBehaviour: MonoBehaviour, IHoldable
    {
        public string DebugName { get; set; }
    }
}
