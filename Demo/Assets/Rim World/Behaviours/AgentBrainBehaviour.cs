using CrashKonijn.Goap.Core;
using CrashKonijn.Goap.Runtime;
using Rim_World.Game.Items;
using Rim_World.Goals;
using UnityEngine;

namespace Rim_World.Behaviours
{
    public class AgentBrainBehaviour : MonoBehaviour
    {
        private IGoap goap;
        private GoapActionProvider provider;
        public AgentType agentType;

        
        private void Awake()
        {
            this.goap = FindObjectOfType<GoapBehaviour>();
            this.provider = this.GetComponent<GoapActionProvider>();
            if (this.agentType == AgentType.WoodWorker)
            {
                this.provider.AgentType = this.goap.GetAgentType("WoodWorker");
            }
        }
        
        private void Start()
        {
            if (this.agentType == AgentType.WoodWorker)
            {
                this.provider.RequestGoal<CreateItemGoal<Box>>();
            }
        }
        
        public enum AgentType
        {
            WoodWorker,
        }
    }
}
