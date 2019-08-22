using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    [Header("Movement Control")]
    [SerializeField] private Rigidbody _tank;
    [SerializeField] private float _speed;
    [SerializeField] private float _turnspeed;
    public float velcity;
    [Header("TurretControl")]
    [SerializeField] Camera _camera;
    [Header("Redicle")]
    [SerializeField] private Transform _reticleTransform;
    [SerializeField] private Transform _turretTransform;
    [SerializeField] private Transform _gunTransform;
    [SerializeField] private float _turretLagSpeed;
    [SerializeField] private float _gunLatSpeed;
    [SerializeField] private Vector2 _rotationAmount;
    [SerializeField] private Vector2 _retOffset;
    [SerializeField] private float _xBufferValue;
    [SerializeField] private float _yBufferValue;
    [SerializeField] private float _xturnSpeed;
    [SerializeField] private float _yturnSpeed;
    private Vector3 finalTurretLookDir;
    private Vector3 finalGunLookDir;
     private Vector2 screenres;
    [SerializeField] private Vector2 mousePos;
    private Vector3 currentRotation;

    //Makes it a get only variable//
    public Vector3 ReticlePosition
    {
        get { return recticlePosition; }
    }
    [SerializeField] private Vector3 RecicleNormal
    {
        get { return recticalNormal; }
    }
    private Vector3 recticlePosition;
    private Vector3 recticalNormal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleInputs();
        HandleReticle();
        HandleTurret();

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

    //look up virtual method//
    protected virtual void HandleInputs()
    { 
        //Gets screen res and uses it to normalize then remap mouse pos values to -1,1 on each axis//
        screenres = new Vector2(Screen.width, Screen.height);
        mousePos = ((Input.mousePosition) / screenres * 2) - new Vector2(1, 1);

    }

    protected virtual void HandleReticle()
    {
        if (_reticleTransform)
        {
            _reticleTransform.position = ReticlePosition;
        }
    }

    protected virtual void HandleTurret()
    {
        if (_turretTransform)
        {
            
            if(Mathf.Abs( mousePos.x) > _xBufferValue)
            {
                currentRotation = _turretTransform.rotation.eulerAngles;
                _turretTransform.rotation = Quaternion.Euler(currentRotation + new Vector3(0, mousePos.x * Time.deltaTime * _xturnSpeed, 0));
            }
            if (Mathf.Abs(mousePos.y) > _yBufferValue)
            {
                _gunTransform.rotation = Quaternion.Euler(new Vector3((-1 * mousePos.y + _retOffset.y) * _rotationAmount.y, _turretTransform.rotation.eulerAngles.y, 0));
            }



         


        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(recticlePosition, 1);

    }

}
