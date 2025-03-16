using CrashKonijn.Agent.Core;
using CrashKonijn.Goap.Core;
using UnityEngine;

namespace Rim_World.Behaviours
{
    public class GoapInjectorBehaviour : MonoBehaviour, IGoapInjector
    {
        public ItemFactoryBehaviour itemFactory;
        
        public void Inject(IAction action)
        {
        }

        public void Inject(IGoal goal)
        {
        }

        public void Inject(ISensor sensor)
        {
        }
    }
}
