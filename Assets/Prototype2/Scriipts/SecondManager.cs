using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SecondManager : MonoBehaviour
{
    [SerializeField] string[] Colors;
    TextMeshProUGUI textBar;
    bool wait = false;
    // Start is called before the first frame update
    void Start()
    {
        textBar = FindObjectOfType<TextMeshProUGUI>();
        textBar.text = "Z";
    }

    // Update is called once per frame
    void Update()
    {
        if (!wait)
        {
            wait = true;
            int rand = Random.Range(0, Colors.Length);
            textBar.text = Colors[rand];
        }
            KeyboardInput();
    }

   public void ButtonPressed(string ButtonColor)
    {
        if (ButtonColor==textBar.text)
        {
            print("correct");
            wait = false;
        }
    }

    void KeyboardInput()
    {
        
        if (Input.GetKeyDown(KeyCode.R)&&textBar.text=="R" )
        {
            wait = false;
            print("R");
        }
        if (Input.GetKeyDown(KeyCode.G) && textBar.text == "G")
        {
            wait = false;
            print("G");

        }
        if (Input.GetKeyDown(KeyCode.B) && textBar.text == "B")
        {
            wait = false;
            print("B");
        }       
    }
}
