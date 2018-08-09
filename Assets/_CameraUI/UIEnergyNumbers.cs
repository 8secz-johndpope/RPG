﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RPG.Characters;

namespace RPG.CameraUI
{
    public class UIEnergyNumbers : MonoBehaviour
    {
        Player player;
        Text energyNumbers;
        float currentEnergyPoints;
        float maxEnergyPoints;
        // Use this for initialization
        void Start()
        {
            player = FindObjectOfType<Player>();
            var energyComponent = player.GetComponent<Energy>();
            energyNumbers = GetComponent<Text>();
            currentEnergyPoints = energyComponent.currentEnergyPoints;
            maxEnergyPoints = energyComponent.maxEnergyPoints;
            energyNumbers.text = "Energy " + currentEnergyPoints + "/" + maxEnergyPoints;

        }

        // Update is called once per frame
        public void Update()
        {
            var energyComponent = player.GetComponent<Energy>();
            print("Energynumberupdate");
            energyNumbers.text = energyComponent.currentEnergyPoints.ToString("F0") + "/" + energyComponent.maxEnergyPoints.ToString("F0");
        }
    }
}