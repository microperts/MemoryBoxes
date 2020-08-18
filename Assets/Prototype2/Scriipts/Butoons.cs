using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butoons : MonoBehaviour
{
   public void Pressed()
    {
        SecondManager secondManager = FindObjectOfType<SecondManager>();
        secondManager.ButtonPressed(transform.name);
    }
}
