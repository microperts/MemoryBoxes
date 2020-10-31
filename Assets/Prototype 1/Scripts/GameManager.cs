using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{

    

    public static bool hasFinishedTutorial=false;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
