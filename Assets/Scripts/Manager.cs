using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
   [SerializeField] ButtonScript[] buttons;
    List<int> topress = new List<int>();
    List<int> pressed=new List<int>();
    bool waiting = false;
    void Start()
    {
        StartCoroutine(PlayNotes());
    }

    

    IEnumerator PlayNotes()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int rand = Random.Range(0, buttons.Length);
            AudioSource source = buttons[rand].GetComponent<AudioSource>();
            source.Play();
            buttons[rand].ShowSelected();
           

            yield return new WaitForSeconds(source.clip.length);
        }
        waiting = true;
    }

    public void Recognise(ButtonScript button)
    {
        if (waiting)
        {
            switch (button.name)
            {
                case "1":
                    pressed.Add(1);
                    break;
                case "2":
                    pressed.Add(2);
                    break;
                case "3":
                    pressed.Add(3);
                    break;
                case "4":
                    pressed.Add(4);
                    break;
                case "5":
                    pressed.Add(5);
                    break;
                case "6":
                    pressed.Add(6);
                    break;
                default:
                    break;
            }
        }
    }
}
