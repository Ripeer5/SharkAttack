using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Controller : MonoBehaviour
{
    public Button returnButton;

    // Start is called before the first frame update
    void Start()
    {
        returnButton.onClick.AddListener(() => {
            SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
