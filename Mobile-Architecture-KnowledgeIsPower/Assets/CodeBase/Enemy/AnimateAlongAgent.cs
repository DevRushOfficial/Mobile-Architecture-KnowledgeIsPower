﻿using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(EnemyAnimator))]
    public class AnimateAlongAgent : MonoBehaviour
    {
        private const float MinimalVelocity = 0.1f;
        
        public NavMeshAgent Agent;
        public EnemyAnimator EnemyAnimator;
        
        private void Update()
        {
            if (ShouldMove())
            {
                EnemyAnimator.MoveEnemy(Agent.velocity.magnitude);
            }
            else
            {
                EnemyAnimator.StopMoving();
            }
        }

        private bool ShouldMove() => 
            Agent.velocity.magnitude > MinimalVelocity && Agent.remainingDistance > Agent.radius;
    }
}