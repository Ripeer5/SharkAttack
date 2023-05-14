using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SharkBoost : MonoBehaviour
{

    [SerializeField] private float tauxGainBoost;
    [SerializeField] private float tauxPerteBoost;
    [SerializeField] private int upSpeed;
    public int maxBoost = 100;
    public float currentBoost;

    public int basicSpeed;

    public SharkMoveController sharkMoveController;

    public BoostBarController boostBar;

    // Start is called before the first frame update
    void Start()
    {
        currentBoost = maxBoost;
        boostBar.SetMaxBoost(maxBoost);
        InvokeRepeating(nameof(IncreaseBoost), 0f, 0.01f);

    }

    // Update is called once per frame
    void Update()
    {
        if (currentBoost <= 0)
        {
            // Le personnage est mort, implémentez ici le comportement souhaité
            currentBoost = 0;
            CancelInvoke(nameof(DecreaseBoost));
            DecreaseSpeed();    
            Debug.Log("Boost à sec");
        }
    }

    private void IncreaseBoost()
    {
        currentBoost = currentBoost + tauxGainBoost;
        boostBar.slider.value = currentBoost;

        if (currentBoost >= 100)
        {
            currentBoost = 100;
        }
    }
    private void DecreaseBoost()
    {
        currentBoost = currentBoost - tauxPerteBoost;
        boostBar.slider.value = currentBoost;

        if (currentBoost <= 0)
        {
            CancelInvoke(nameof(DecreaseBoost));
        }
    }
    public void IncreaseSpeed()
    {
        sharkMoveController.SetMoveSpeed(upSpeed);
        InvokeRepeating(nameof(DecreaseBoost), 0f, 0.01f);
        CancelInvoke(nameof(IncreaseBoost));    
    }
    public void DecreaseSpeed()
    {
        sharkMoveController.SetMoveSpeed(basicSpeed);
        CancelInvoke(nameof(DecreaseBoost));
        InvokeRepeating(nameof(IncreaseBoost), 0f, 0.01f);

    }
}
