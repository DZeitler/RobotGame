using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _tank;
    [SerializeField] private float _speed;
    [SerializeField] private float _turnspeed;
    public float velcity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //forward//
        if (Input.GetKey(KeyCode.W))
        {
            _tank.AddForce(_tank.transform.forward * _speed, ForceMode.Impulse);
        }
        //backward//
        if (Input.GetKey(KeyCode.S))
        {
            _tank.AddForce(-1* (_tank.transform.forward * _speed), ForceMode.Impulse);
        }

        //body rotation//
        //rotate left//
        if (Input.GetKey(KeyCode.A))
        {
            _tank.transform.Rotate(new Vector3(0, -1 *_turnspeed, 0));
        }
        //rotate right//
        if (Input.GetKey(KeyCode.D))
        {
            _tank.transform.Rotate(new Vector3(0, 1 * _turnspeed, 0));
        }

        velcity = _tank.velocity.magnitude;
    }
}
