using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text scoreText;  // Référence au texte de score dans l'UI
    private int score = 0;  // Score initial
    public int whalePoints;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fish"))
        {
            Vector3 contactPoint = other.ClosestPointOnBounds(transform.position);
            if (contactPoint != null)
            {
                if (contactPoint.z > 0)
                {
                    score=score+10;  // Augmenter le score de 1
                    scoreText.text = "Score: " + score.ToString();  // Mettre à jour le texte du score dans l'UI
                }
            }
        }
        else if (other.gameObject.CompareTag("Whale"))
        {
            Vector3 contactPoint = other.ClosestPointOnBounds(transform.position);
            if (contactPoint != null)
            {
                if (contactPoint.z > 0)
                {
                    score += whalePoints;  // Augmenter le score de 1
                    scoreText.text = "Score: " + score.ToString();  // Mettre à jour le texte du score dans l'UI
                }
            }
        }
    }
    public int getScore()
    {
        return score;
    }
}
