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
    [Header("Tutorial UI stuff")]
    [Space]
    [SerializeField] GameObject timerText;
    [SerializeField] GameObject waitMessage;
    [SerializeField] GameObject letsDoThatAgain;
    [Space]
    [Header("Gameplay UI objects")]
    [SerializeField] bool isUI = false;
    [SerializeField] GameObject rewardBox;
    [SerializeField] Sprite[] images;
    [SerializeField] GameObject disgrace;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Text scoreN_Text;
    [SerializeField] Text streakText;

    [SerializeField] float secondsToReloadScene = 3f;

    int highest=0;
    int score;
    AudioSource source;
    Transform startReward;


    private void Start()
    {            
        source = GetComponent<AudioSource>();
        startReward = rewardBox.transform;
        Time.timeScale = 0.5f;
        score = 0;
    }
    public void AddTimesCorrect()
    {
        AudioSource prize = GetComponent<AudioSource>();
        winStreak++;
        highest++;

        score +=100*multiplier();
        int x = 100 * multiplier();
        Time.timeScale+= 0.1f;

        //Show the + watever the score is times the multiplier
        StartCoroutine(ShowRewardText(x.ToString()));

        //Logic to change the multiplier
        if (winStreak == 2)
        {
            streakText.text ="x" + multiplier();         
        }
        if (winStreak == 3)
        {
            streakText.text = "x" + multiplier();
        }
        if (winStreak == 7)
        {
            streakText.text = "x" + multiplier();
        }
        if (winStreak == 10)
        {
            streakText.text = "x" + multiplier();
        }
    }

    public void ResetWinStreak()
    {        
        winStreak = 0;
        streakText.text = "x" + multiplier();
    }

    IEnumerator ShowRewardText(string rewardText)
    {
        Text textBox = rewardBox.GetComponent<Text>();
        Animator anim = textBox.GetComponent<Animator>();        
        textBox.text = rewardText;
        anim.Play("Show");
       // this.rewardText.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        textBox.text = "";
        scoreN_Text.text = score.ToString();
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
  
    IEnumerator TutorialShow(GameObject screen)
    {
        screen.SetActive(true);
        Time.timeScale = 0f;
        yield return new WaitForSeconds(3f);

    }
    int multiplier()
    {
        if (winStreak == 0)
        {
            return 1;
        }
         return winStreak;
    }

}
