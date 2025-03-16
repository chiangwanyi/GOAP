using System.Collections.Generic;
using System.Linq;
using Rim_World.Game;
using UnityEngine;

namespace Rim_World.Behaviours
{
    public class ItemBlueprintManager : MonoBehaviour
    {
        public List<Blueprint> blueprintObjects = new();

        public Blueprint[] Filtered<T>(bool noAgent = false)
        {
            var blueprints = this.blueprintObjects as IEnumerable<Blueprint>;
            blueprints = blueprints.Where(x => x.item is T);
            if (noAgent)
                blueprints = blueprints.Where(x => string.IsNullOrEmpty(x.agentName));
            return blueprints.ToArray();
        }
        
        public Blueprint Closest<T>(Vector3 position)
        {
            var blueprints = this.Filtered<T>(true);
            Blueprint closest = null;
            var closestDistance = float.MaxValue; // Start with the largest possible distance

            foreach (var blueprint in blueprints)
            {
                var distance = Vector3.Distance(blueprint.gameObject.transform.position, position);
                
                if (!(distance < closestDistance))
                    continue;
                
                closest = blueprint;
                closestDistance = distance;
            }
            
            return closest;
        }

        public Blueprint GetByAgentName<T>(string agentName)
        {
            var blueprints = this.Filtered<T>();
            return blueprints.FirstOrDefault(x => x.agentName == agentName);
        }

        public void TakenBlueprint<T>(Blueprint blueprint, string agentName)
        {
            var taken = this.GetByAgentName<T>(agentName);
            if (taken == null)
            {
                blueprint.agentName = agentName;
            }
        }

        public void Remove(Blueprint blueprint)
        {
            this.blueprintObjects.Remove(blueprint);
            blueprint.transform.parent = null;
            Destroy(blueprint.gameObject);
        }
    }
}
