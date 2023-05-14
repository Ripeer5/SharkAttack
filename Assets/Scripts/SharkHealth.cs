
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SharkHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public float loseHealthRate;
    public int fishHealthBonus;
    public int whaleHealthBonus;
    public GameObject shark;

    private bool isSpawn= false;
    public HealthBarController healthBar;

   
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            // Le personnage est mort, implémentez ici le comportement souhaité
            currentHealth = 0;
            Debug.Log("Le personnage est mort");
        }
        if (shark.activeInHierarchy)
        {
            if (!isSpawn)
            {
                InvokeRepeating(nameof(DecreaseHealth), 1f, 0.1f);
                isSpawn = true;
            }
            else return;
            ;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fish"))
        {
            Vector3 contactPoint = other.ClosestPointOnBounds(transform.position);
            if (contactPoint != null)
            {
                if (contactPoint.z > 0)
                {
                    // Regagne de la vie
                    currentHealth += fishHealthBonus; // Exemple : regagne 20 points de vie
                    healthBar.SetHealth(currentHealth);
                    // Limite la vie maximale à 100 points
                    currentHealth = Mathf.Clamp(currentHealth, 0, 100);
                    Destroy(other.gameObject);  // Faire disparaître l'objet B 
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
                    // Regagne de la vie
                    currentHealth += whaleHealthBonus; // Exemple : regagne 20 points de vie
                    healthBar.SetHealth(currentHealth);
                    // Limite la vie maximale à 100 points
                    currentHealth = Mathf.Clamp(currentHealth, 0, 100);
                    Destroy(other.gameObject);  // Faire disparaître l'objet B 
                }
            }
        }
    }

    private void DecreaseHealth()
    {
        currentHealth = currentHealth - loseHealthRate;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            CancelInvoke(nameof(DecreaseHealth));
        }
    }
    public float getHealth()
    {
        return currentHealth;
    }
}
