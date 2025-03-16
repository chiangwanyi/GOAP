using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Rim_World.Behaviours
{
    public class ItemFactoryBehaviour : MonoBehaviour
    {
        private int count;
        
        public List<ItemBehaviour> items = new();
        
        public T Instantiate<T>() where T : ItemBehaviour
        {
            var item = this.items.FirstOrDefault(x => x is T);

            if (item == null)
                throw new System.Exception($"Item of type {typeof(T).Name} not found in factory");
            
            // Instantiate the item
            var instance = Instantiate(item);

            var itemInstanceName = $"{typeof(T).Name} - {this.count}";
            instance.transform.name = itemInstanceName;
            instance.DebugName = itemInstanceName;

            this.count++;
            
            return instance as T;
        }
    }
}
