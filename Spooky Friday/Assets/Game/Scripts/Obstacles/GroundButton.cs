using System;
using UnityEngine;

public class GroundButton : MonoBehaviour
{
   [SerializeField] private Transform connectedGate;
   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         Debug .Log("Button is pressed");
      }
   }
}
