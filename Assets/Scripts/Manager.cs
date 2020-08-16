using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
   [SerializeField] ButtonScript[] buttons;
    List<int> toPress = new List<int>();
    List<int> pressed=new List<int>();
    bool waiting = false;
    int timesPressed=0;
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
            toPress.Add(rand);
            
           
            yield return new WaitForSeconds(source.clip.length);
        }
        waiting = true;

        for (int i = 0; i < toPress.Count; i++)
        {
            print(toPress[i]);
        }
    }

    public void Recognise(ButtonScript button)
    {
        if (waiting)
        {
            if (timesPressed<toPress.Count)
            {
                switch (button.name)
                {
                    case "1":
                        pressed.Add(1);
                        timesPressed++;
                        break;
                    case "2":
                        pressed.Add(2);
                        timesPressed++;
                        break;
                    case "3":
                        pressed.Add(3);
                        timesPressed++;
                        break;
                    case "4":
                        pressed.Add(4);
                        timesPressed++;
                        break;
                    case "5":
                        pressed.Add(5);
                        timesPressed++;
                        break;
                    case "6":
                        pressed.Add(6);
                        timesPressed++;
                        break;
                    default:
                        break;
                }              
            }
            else
            {
                return;
            }

            CheckIfCorrect();
        }
    }
    void CheckIfCorrect()
    {
        //Pressed buttons start at 1 and toPress start at 1 so you have to minus here when checking
        if (pressed[timesPressed-1] == toPress[timesPressed-1])
        {
            print("Correct my dear");
        }
        else
        {
            print("Wroooong");
        }

    }
}
