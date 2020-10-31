using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    [SerializeField] float desTimeUI = 3f;

    void Start()
    {
        Invoke("KillSelf", desTimeUI);
    }

    void KillSelf()
    {
        gameObject.SetActive(false);
    }
}
