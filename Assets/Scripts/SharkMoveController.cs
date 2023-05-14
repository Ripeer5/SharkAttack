using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[RequireComponent(typeof(Rigidbody))]
public class SharkMoveController : MonoBehaviour
{
    //Gestion des mouvements :
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private FixedJoystick _joystick;
    public void SetMoveSpeed(int speed)
    {
        _moveSpeed = speed;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);

            Vector3 movement = new Vector3(_joystick.Horizontal * _moveSpeed, 0f, _joystick.Vertical * _moveSpeed);
            transform.position += movement * Time.deltaTime;

        }
    }
}

    
