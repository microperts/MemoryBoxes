using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    PlayerController manager;
    Animator animator;
    Button thisButton;
    ColorBlock temp;
    [SerializeField] Color wrongColor;

    private void Start()
    {
      manager = FindObjectOfType<PlayerController>();
      animator = GetComponent<Animator>();
      thisButton = GetComponent<Button>();
      temp = thisButton.colors;
    }
    public void PlayTone()
    {
        AudioSource source = GetComponent<AudioSource>();

        if (source.isPlaying) source.Stop();
        if (!source.isPlaying&&manager.waiting)
        {
            source.Play();
        }       
    }

    public void ShowSelected()
    {
        Button but = GetComponent<Button>();
        but.Select();
    }

    public void PressedBox()
    {
        manager = FindObjectOfType<PlayerController>();
        manager.Recognise(this);
    }
    public void ColorChanger()
    {
        
        ColorBlock cBlock = thisButton.colors;
        cBlock.pressedColor = wrongColor;
        cBlock.selectedColor = wrongColor;
        thisButton.colors = cBlock;
    }

    public void ResetColors()
    {
        thisButton.colors = temp;
    }
    public void SwitchOn(bool color)
    {
        if (color)
        {
            ColorBlock on = thisButton.colors;
            on.normalColor = Color.green;
            thisButton.colors = on;
        }
        else
        {
            ColorBlock on = thisButton.colors;
            on.normalColor =wrongColor;
            thisButton.colors = on;
        }
    }


}
