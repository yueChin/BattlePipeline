using System;
using UnityEngine;

namespace Pipeline
{
    public class GameEnter : MonoBehaviour
    {
        private GameLoop m_GameLoop;
        public void Awake()
        {
            m_GameLoop = new GameLoop();
        }

        public void Start()
        {
            
        }

        public void Update()
        {
            m_GameLoop.Update();
        }

        public void FixedUpdate()
        {
            m_GameLoop.FixedUpdate();
        }
    }
}