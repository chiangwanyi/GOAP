﻿using System.Collections.Generic;
using System.Linq;
using LamosInteractive.Goap.Interfaces;
using Unity.Mathematics;
using UnityEngine;

namespace CrashKonijn.Goap.Resolver
{
    public class PositionBuilder
    {
        private readonly List<IAction> actionIndexList;
        private float3[] executableList;

        public PositionBuilder(List<IAction> actionIndexList)
        {
            this.actionIndexList = actionIndexList;
            this.executableList = this.actionIndexList.Select(x => GraphResolverJob.InvalidPosition).ToArray();
        }
        
        public PositionBuilder SetPosition(IAction action, Vector3 position)
        {
            var index = this.actionIndexList.IndexOf(action);
            
            this.executableList[index] = position;

            return this;
        }
        
        public float3[] Build()
        {
            return this.executableList;
        }

        public void Clear()
        {
            this.executableList = this.actionIndexList.Select(x => GraphResolverJob.InvalidPosition).ToArray();
        }
    }
}