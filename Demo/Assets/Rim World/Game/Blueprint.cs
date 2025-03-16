using Rim_World.Behaviours;
using UnityEngine;

namespace Rim_World.Game
{
    public class Blueprint : MonoBehaviour
    {
        public ItemBehaviour item;
        public string agentName;

        public void Spawn()
        {
            if (this.item == null)
            {
                Debug.LogError("No item found for blueprint");
                return;
            }

            Instantiate(this.item, this.transform);
        }
    }
}
