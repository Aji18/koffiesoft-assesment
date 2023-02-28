using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject endGamePanel;

    public AudioSource clickAudio;
    public AudioSource bgAudio;
    
        
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI score2Text;
    [SerializeField] private TextMeshProUGUI timertext;
    
    private bool timerIsRunning = false;
    
    private float timeRemaining = 10;
    private float score = 0;

    void Start()
    {
      bgAudio.Play();
      menuPanel.SetActive(true);
      scoreText.text = score.ToString();
    }

    public void Play()
    {
	    clickAudio.Play();
	    timerIsRunning = true;
	    menuPanel.SetActive(false);
	    gamePanel.SetActive(true);
    }
    
    public void Tap()
    {
    	clickAudio.Play();
    	score ++;
    	scoreText.text = score.ToString();
        score2Text.text = score.ToString();
    }
    
    public void Retry()
    {
    	clickAudio.Play();
    	score = 0;
    	scoreText.text = score.ToString();
    	timeRemaining = 10;
    	timerIsRunning = true;
        endGamePanel.SetActive(false);
        scoreText.text = score.ToString();
    }
    
    private void DisplayTime(float timeToDisplay)
    {
    	timeToDisplay += 1;
    	float minutes = Mathf.FloorToInt(timeToDisplay / 60);
    	float seconds = Mathf.FloorToInt(timeToDisplay % 60);
    	timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Update is called once per frame
    void Update()
    {
        if(timerIsRunning)
        {
        	if(timeRemaining > 0)
        	{
        		timeRemaining -= Time.deltaTime;
        		DisplayTime(timeRemaining);
        	}
        	else
        	{
        		Debug.Log("Time Out");
        		timeRemaining = 0;
        		timerIsRunning = false;
        		endGamePanel.SetActive(true);
        	}
        }
    }
}
