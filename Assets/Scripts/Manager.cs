using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    ButtonScript [] buttons;
    bool waiting = false;
    void Start()
    {
        buttons = FindObjectsOfType<ButtonScript>();
        StartCoroutine(PlayNotes());
    }

    void Update()
    {
        if (waiting)
        {
            print("Wainting");
            StopAllCoroutines();
        }
    }
  
   IEnumerator PlayNotes()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int rand = Random.Range(0, buttons.Length);
            AudioSource source = buttons[rand].GetComponent<AudioSource>();
            source.Play();
            buttons[rand].ShowSelected();
            print(rand);
            
            yield return new WaitForSeconds(source.clip.length);
        }
        waiting = true;
    }

}
