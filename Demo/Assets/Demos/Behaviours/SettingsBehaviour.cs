﻿using System;
using System.Linq;
using CrashKonijn.Goap.Behaviours;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Demos.Behaviours
{
    
    public class SettingsBehaviour : MonoBehaviour
    {
        private static readonly Vector2 Bounds = new Vector2(15, 8);
        
        public GameObject applePrefab;
        public GameObject agentPrefab;
        public GoapSetBehaviour goapSet;
        
        public TextMeshProUGUI appleCountText;
        public TextMeshProUGUI agentCountText;
        public TextMeshProUGUI fpsText;

        private bool debug = true;
        private GoapRunnerBehaviour goapRunner;

        private int frameCount;
        private float fps;
        private float fpsTimer;
        
        private AppleCollection apples;

        private void Awake()
        {
            this.agentPrefab.SetActive(false);
            this.goapRunner = FindObjectOfType<GoapRunnerBehaviour>();
            this.apples = FindObjectOfType<AppleCollection>();
            
            Screen.SetResolution(1024, 576, false);
        }

        private void Update()
        {
            this.frameCount++;
            this.fpsTimer += Time.deltaTime;

            if (this.fpsTimer >= 1)
            {
                this.fps = this.frameCount;
                this.frameCount = 0;
                this.fpsTimer -= 1;
            }
            
            this.fpsText.text = $"FPS: {this.fps}\nRunTime: {this.goapRunner.RunTime} (ms)\nCompleteTime: {this.goapRunner.CompleteTime} (ms)";
        }

        private void FixedUpdate()
        {
            this.appleCountText.text = $"+ Apple ({this.apples.Get().Length})";
            this.agentCountText.text = $"+ Agent ({this.goapRunner.Agents.Length})";
        }

        public void SetDebug(bool value)
        {
            this.debug = value;
            
            foreach (var textBehaviour in FindObjectsOfType<TextBehaviour>())
            {
                this.SetDebug(textBehaviour, value);
            }
        }

        private void SetDebug(TextBehaviour textBehaviour, bool value)
        {
            textBehaviour.enabled = value;
            textBehaviour.GetComponentInChildren<Canvas>().enabled = value;
        }

        public void SpawnApple()
        {
            for (int i = 0; i < 50; i++)
            {
                Instantiate(this.applePrefab, this.GetRandomPosition(), Quaternion.identity);
            }
        }

        public void SpawnAgent()
        {
            var agentCount = this.goapRunner.Agents.Length;
            var count = agentCount < 50 ? 50 - agentCount : 50;
            
            for (int i = 0; i < count; i++)
            {
                var agent = Instantiate(this.agentPrefab, this.GetRandomPosition(), Quaternion.identity).GetComponent<AgentBehaviour>();
                agent.GoapSet = this.goapSet.Set;
            
                this.SetDebug(agent.GetComponentInChildren<TextBehaviour>(), this.debug);
            
                agent.gameObject.SetActive(true);
            }
        }
        
        private Vector3 GetRandomPosition()
        {
            var randomX = Random.Range(-Bounds.x, Bounds.x);
            var randomY = Random.Range(-Bounds.y, Bounds.y);
            
            return new Vector3(randomX, 0f, randomY);
        }
    }
}