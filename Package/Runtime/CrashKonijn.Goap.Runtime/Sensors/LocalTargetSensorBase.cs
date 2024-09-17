﻿using System;
using CrashKonijn.Agent.Core;
using CrashKonijn.Goap.Core;

namespace CrashKonijn.Goap.Runtime
{
    public abstract class LocalTargetSensorBase : ILocalTargetSensor
    {
        public ITargetKey Key => this.Config.Key;
        public ITargetSensorConfig Config { get; private set; }
        public void SetConfig(ITargetSensorConfig config) => this.Config = config;
        
        public abstract void Created();
        public abstract void Update();
        public Type[] GetKeys() => new[] { this.Key.GetType() };

        public void Sense(IWorldData worldData, IActionReceiver agent, IComponentReference references)
        {
            worldData.SetTarget(this.Key, this.Sense(agent, references, worldData.GetTargetValue(this.Key.GetType())));
        }

        public abstract ITarget Sense(IActionReceiver agent, IComponentReference references, ITarget existingTarget);
        
        [Obsolete("This should not be used anymore! Use 'Sense(IActionReceiver agent, IComponentReference references, ITarget existingTarget) instead'")]
        public virtual ITarget Sense(IActionReceiver agent, IComponentReference references)
        {
            throw new GoapException("This should not be called anymore!");
        }

        [Obsolete("This should not be used anymore! Use 'Sense(IActionReceiver agent, IComponentReference references)'")]
        public virtual ITarget Sense(IMonoAgent agent, IComponentReference references)
        {
            throw new GoapException("This should not be called anymore!");
        }
    }
}