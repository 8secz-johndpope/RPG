﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Characters
{
    [CreateAssetMenu(menuName = ("RPG/Special Ability/Healing"))]
    public class HealingConfig : AbilityConfig
    {
        [Header("Healing Config")]
        [SerializeField] float healthGained = 30;

        public override void AttachComponent(GameObject gameObjectToattachTo)
        {
            var behaviourComponent = gameObjectToattachTo.AddComponent<HealingBehaviour>();
            behaviourComponent.setConfig(this);
            behaviour = behaviourComponent;
        }

        public float GetHealthGained()
        {
            return healthGained;
        }
    }
}