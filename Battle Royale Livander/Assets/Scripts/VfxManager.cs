using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VfxManager : MonoBehaviour
{
    public GameObject woodImpact, bloodImpact;
    
    public static VfxManager instance;

    private void Awake()
    {
        instance = this;
    }
}
