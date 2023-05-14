using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkAnimationsController : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Moving", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fish"))
        {
            Vector3 contactPoint = other.ClosestPointOnBounds(transform.position);
            if (contactPoint != null)
            {
                if(contactPoint.z > 0 )
                {
                    animator.SetTrigger("isEating");
                }
            }
            
        }
    }
}
