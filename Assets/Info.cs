using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class Info : MonoBehaviour
{
    private string word1 = "GEN";
    private int winStreak = 0;
    [SerializeField] bool isUI = false;
    [SerializeField] GameObject rewardText;
    [SerializeField] Sprite[] images;
    [SerializeField] GameObject disgrace;
    [SerializeField] TextMeshProUGUI scoreText;
    public float secondsToReloadScene = 3f;
    int highest=0;
    AudioSource source;



    private void Start()
    {
        if (isUI)
        {
            Invoke("KillSelf", 3f);
        }
        source = GetComponent<AudioSource>();
    }
    public void AddTimesCorrect()
    {
        AudioSource prize = GetComponent<AudioSource>();
        winStreak++;
        highest++;
        if (winStreak == 2)
        {
           StartCoroutine( ShowRewardText("x2"));
            prize.Play();
        }
        if (winStreak == 4)
        {
            ShowRewardText("NICE");
            prize.Play();
        }
        if (winStreak == 5)
        {
            ShowRewardText("x5");
            prize.Play();
        }
        if (winStreak == 7)
        {
            ShowRewardText("GENIUS");
        }
        if (winStreak == 10)
        {
            ShowRewardText("X10");
        }


        if (winStreak == word1.Length)
        {
            print(word1);
        }
    }
    public void ResetWinStreak()
    {        
        winStreak = 0;
    }

    IEnumerator ShowRewardText(string _rewardText)
    {
        Text _text = rewardText.GetComponent<Text>();
        _text.text = _rewardText;
        rewardText.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        _text.text = "";
    }


    void KillSelf()
    {        
        gameObject.SetActive(false);       
    }

    public void Showdisgrace()
    {        
        disgrace.SetActive(true);       
        scoreText.text = highest.ToString();        
        Invoke("restart", secondsToReloadScene);
    }
    void restart()
    {
        SceneManager.LoadScene(0);
    }
}
