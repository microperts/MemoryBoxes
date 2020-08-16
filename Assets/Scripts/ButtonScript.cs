using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public void PlayTone()
    {
        AudioSource source = GetComponent<AudioSource>();
        if (!source.isPlaying)
        {
            source.Play();
        }
    }

    public void ShowSelected()
    {
        Button button = GetComponent<Button>();
        button.Select();
    }

    public void PressedBox()
    {
        Manager manager = FindObjectOfType<Manager>();
        manager.Recognise(this);
    }
}
