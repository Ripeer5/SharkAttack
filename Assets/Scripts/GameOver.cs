using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Niantic.ARDK.Extensions;

public class GameOver : MonoBehaviour
{
    public GameObject gameCanva;
    public GameObject gameOverCanva;
    
    public ScoreController scoreController;
    private int score = 0;
    public TextMeshProUGUI scoreText;

    public SharkHealth sharkHealth;

    public ARSessionManager sessionManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameOverCanva.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if (sharkHealth.getHealth() <= 0)
        {
            ItsGameOver();

        }
    }

    private void ItsGameOver()
    {
        score = scoreController.getScore();
        scoreText.text = "Your Score :" + score;
        gameCanva.SetActive(false);
        gameOverCanva.SetActive(true);
        sessionManager.Deinitialize();
    }
}
