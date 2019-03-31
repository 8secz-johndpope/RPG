﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RPG.Core;

namespace RPG.Characters //consider changing to core
{
    public class PlayerInput : MonoBehaviour
    {
        Player player;
        Character _character;
        CharacterMovement character;
        [SerializeField] float damageCaused = 10;
        Canvas HUD;

        [SerializeField] GameObject inventoryGameObject;
        [SerializeField] GameObject characterPanelGameObject;
        [SerializeField] GameObject siblingIndexer;
        [SerializeField] InputField inputField;

        [SerializeField] int lastChildIndex;


        //KeyBinds
        public KeyCode Crouch = KeyCode.Z;
        public KeyCode SelfDamage = KeyCode.L;
        public KeyCode Exp = KeyCode.K;
        public KeyCode SkillBar1 = KeyCode.Alpha1;
        public KeyCode Revive = KeyCode.J;
        public KeyCode CommandButton = KeyCode.LeftControl;
        public KeyCode hideHud = KeyCode.O;
        public KeyCode Inventory = KeyCode.I;
        public KeyCode CharacterPanel = KeyCode.H;
        public KeyCode targetNearest = KeyCode.C;
        public KeyCode targetNext = KeyCode.Tab;

        public bool HUDHidden;

        // Use this for initialization
        void Start()
        {
            player = FindObjectOfType<Player>();
            _character = FindObjectOfType<Character>();
            HUD = FindObjectOfType<Canvas>();
            siblingIndexer.transform.SetAsLastSibling();
            lastChildIndex = siblingIndexer.transform.GetSiblingIndex();
        }
        public void SetDamage(float damage)
        {
            damageCaused = damage;
        }


        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(targetNearest))
            {
                _character.SetNearestTarget();
            }
            if(Input.GetKeyDown(targetNext))
            {
                _character.GetNextTarget();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //if ()
                //{

                //}
            }
            if (Input.GetKeyDown(Inventory) && !inputField.isFocused)
            {
                toggleInventory();                
            }

            if (Input.GetKeyDown(CharacterPanel))
            {
                toggleCharacterPanel();
                Debug.Log("Toggle Character");
            }


            if (Input.GetKey(CommandButton))
            {
                print("ctrl pressed");
                if (Input.GetKeyDown(hideHud))
                {
                    print("HideHud?");
                    HideHud();
                }
            }

            ////crouching
            if (Input.GetKey(Crouch))
            {
                character.crouching = true;
            }
            else
            {
                character.crouching = false;
            }

            if (character.crouching)
            {
                print("Crouching!");
            }

            if (Input.GetKeyDown(SelfDamage))
            {
                Component damageableComponent = player;


                (damageableComponent as IDamageable).TakeDamage(damageCaused);
                player.timeSinceLastDamaged = Time.time;
                print("Dealt 10dmg to Self!");
                if (player.currentHealthPoints <= 0)
                {
                    StartCoroutine(player.TriggerDeath());
                }
            }
            if(Input.GetKeyDown(Revive))
            {
                player.Respawn();
            }
            //TODO uncomment after fix EXP
            //if (Input.GetKeyDown(Exp))
            //{
            //   player.experiencePoints += 12;
            //}
        }

        private void HideHud()
        {
            if (!HUDHidden)
            {
                HUDHidden = true;
                HUD.enabled = !enabled;
            }
            else if(HUDHidden)
            {
                HUDHidden = false;
                HUD.enabled = enabled;
            }
        }

        public void toggleInventory()
        {
            if (inventoryGameObject.activeInHierarchy == true & inventoryGameObject.transform.GetSiblingIndex() != lastChildIndex)
            {
                inventoryGameObject.transform.SetAsLastSibling();
            }
            else if (inventoryGameObject.transform.GetSiblingIndex() == lastChildIndex || inventoryGameObject.activeInHierarchy == false)
            {
                inventoryGameObject.SetActive(!inventoryGameObject.activeSelf);
            }
        }

        public void toggleCharacterPanel()
        {
            if (characterPanelGameObject.activeInHierarchy == true & characterPanelGameObject.transform.GetSiblingIndex() != lastChildIndex)
            {
                characterPanelGameObject.transform.SetAsLastSibling();
            }
            else if (characterPanelGameObject.transform.GetSiblingIndex() == lastChildIndex || characterPanelGameObject.activeInHierarchy == false)
            {
                characterPanelGameObject.SetActive(!characterPanelGameObject.activeSelf);
            }
        }
    }
}