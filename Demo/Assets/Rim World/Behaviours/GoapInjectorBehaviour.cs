using CrashKonijn.Agent.Core;
using CrashKonijn.Goap.Core;
using Rim_World.Interfaces;
using UnityEngine;

namespace Rim_World.Behaviours
{
    public class GoapInjectorBehaviour : MonoBehaviour, IGoapInjector
    {
        public ItemBlueprintManager itemBlueprintManager;
        
        public void Inject(IAction action)
        {
            if (action is IInjectable injectable)
                injectable.Inject(this);
        }

        public void Inject(IGoal goal)
        {
        }

        public void Inject(ISensor sensor)
        {
            if (sensor is IInjectable injectable)
                injectable.Inject(this);
        }
    }
}
