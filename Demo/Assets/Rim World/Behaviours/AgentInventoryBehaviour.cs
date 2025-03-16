using System.Collections.Generic;
using System.Linq;
using Rim_World.Interfaces;
using UnityEngine;

namespace Rim_World.Behaviours
{
    public class AgentInventoryBehaviour : MonoBehaviour
    {
        private List<IHoldable> items = new();
        
        public T[] Get<T>()
        {
            return this.items.Where(x => x is T).Cast<T>().ToArray();
        }
        
        public void Remove<T>(T item)
            where T : IHoldable
        {
            this.items.Remove(item);
            
            if (item == null || item.gameObject == null)
                return;
            
            // 需要保留物品但将其从当前逻辑中移除，设置 parent = null 是一种常见的做法。
            item.gameObject.transform.parent = null;
        }
        
        public int Count<T>()
            where T : IHoldable
        {
            return this.items.Count(x => x is T);
        }
    }
}
