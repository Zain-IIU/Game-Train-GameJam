using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Poison : MonoBehaviour
{
    [SerializeField] private GameObject venomVFX;

   
    public void EnablePoison()
    {
        venomVFX.SetActive(true);
        Destroy(this.gameObject,0.5f);
    }
}
