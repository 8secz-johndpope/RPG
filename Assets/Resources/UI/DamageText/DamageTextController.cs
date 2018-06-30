﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextController : MonoBehaviour {

    private static DamageFloatText damageText;
    private static DamageFloatText critText;
    private static DamageFloatText dodgeText;
    private static GameObject canvas;

    public static void Initialize()
    {
        canvas = GameObject.Find("GameCanvas");
        if (!damageText)
        {
            damageText = Resources.Load<DamageFloatText>("UI/DamageText/DamageTextParent");
        }
        if(!critText)
        {
            critText = Resources.Load<DamageFloatText>("UI/DamageText/CritDamageTextParent");
        }
    }

    public static void CreateFloatingDamageText(string text, Transform location)
    {
        DamageFloatText instance = Instantiate(damageText);
        instance.transform.SetParent(canvas.transform, false);
        instance.SetText(text);
    }
    public static void CreateFloatingCritDamageText(string text, Transform location)
    {
        DamageFloatText instance = Instantiate(critText);
        instance.transform.SetParent(canvas.transform, false);
        instance.SetText(text);
    }
    public static void CreateFloatingDodgeText(string text, Transform location)
    {
        DamageFloatText instance = Instantiate(dodgeText);
        instance.transform.SetParent(canvas.transform, false);
        instance.SetText(text);
    }

}
