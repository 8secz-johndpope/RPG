﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Weapons;

namespace RPG.Characters
{
    public class HealingBehaviour : AbilityBehaviour
    {
        Character player = null;
        ParticleSystem skillEffect = null;
        AudioSource audioSource = null;

        // Use this for initialization
        void Start()
        {
            player = GetComponent<Character>();
            audioSource = GetComponent<AudioSource>();
        }

        public override void Use(AbilityUseParams useParams)
        {
            PlaySkillParticleEffect();
            audioSource.clip = config.GetRandomAbilitySound();
            audioSource.Play();
            if(player.GetCurrentHealth() != player.GetMaxHealth())
            {
                player.Heal((config as HealingConfig).GetHealthGained());
                DamageTextController.CreateFloatingHealingText((config as HealingConfig).GetHealthGained().ToString(), transform);
                print("Healing Skill = " + -(config as HealingConfig).GetHealthGained());
            }
            else
            {
                return;
            }
        }
    }
}