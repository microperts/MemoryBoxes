using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    Manager manager;
    private void Start()
    {
      manager = FindObjectOfType<Manager>();

    }
    public void PlayTone()
    {
        AudioSource source = GetComponent<AudioSource>();
        if (!source.isPlaying&&manager.waiting)
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
        manager = FindObjectOfType<Manager>();
        manager.Recognise(this);
    }
}
