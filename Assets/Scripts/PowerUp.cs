﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum TypePower
    {
        fireRate,
        PowerShort
    }

    [SerializeField] TypePower typePower;


}
