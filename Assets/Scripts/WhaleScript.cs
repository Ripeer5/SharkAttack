using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleScript : MonoBehaviour
{
    public GameObject shark;
    public float whaleSpeed = 2f;

    private Vector3 sharkPosition;
    private Vector3 previousPosition;

    // Start is called before the first frame update
    void Start()
    {
        sharkPosition = shark.transform.position;
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(sharkPosition, Vector3.up, whaleSpeed * Time.deltaTime);
        // Calcule la direction actuelle du mouvement
        Vector3 direction = transform.position - previousPosition;

        if (direction != Vector3.zero)
        {
            // Fait tourner le GameObject pour qu'il regarde dans la direction du mouvement
            transform.rotation = Quaternion.LookRotation(-direction);
        }
        previousPosition = transform.position;
    }
}
