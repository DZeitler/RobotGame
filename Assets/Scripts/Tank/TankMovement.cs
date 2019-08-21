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
    [SerializeField] Vector2 _rotationAmount;
    [SerializeField] Vector2 _retOffset;
    private Vector3 finalTurretLookDir;
    private Vector3 finalGunLookDir;
    [SerializeField] private Vector2 screenres;
    [SerializeField]  private Vector2 mousePos;

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
    { /*
        //uses mouse position to cast ray into the scene//
        Ray screenray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //takes raycast from mouse position and stores it in hit//
        LayerMask layerM = LayerMask.GetMask("Ground");
        if(Physics.Raycast(screenray, out hit,Mathf.Infinity, layerM))
        {
            recticlePosition = hit.point;
            recticalNormal = hit.normal;
        }
        */
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
            /*
             Vector3 lookDir = (ReticlePosition -  _turretTransform.position);
             Vector3 turrentdirection = (ReticlePosition - _turretTransform.position);
             turrentdirection.y = .5f;


             //adds turret look lag//
             finalTurretLookDir = Vector3.Lerp(finalTurretLookDir, turrentdirection, Time.deltaTime * _turretLagSpeed);
             finalGunLookDir = Vector3.Lerp(finalGunLookDir, lookDir, Time.deltaTime * _gunLatSpeed);
             finalGunLookDir.y = finalGunLookDir.y - .25f;
             _gunTransform.rotation = Quaternion.LookRotation(finalGunLookDir);
             _turretTransform.rotation = Quaternion.LookRotation(finalTurretLookDir);
            */
            
            _turretTransform.rotation = Quaternion.Euler( new Vector3(0, mousePos.x * _rotationAmount.x, 0));
            _gunTransform.rotation = Quaternion.Euler(new Vector3((-1 *mousePos.y +_retOffset.y) * _rotationAmount.y, mousePos.x * _rotationAmount.x, 0));



            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(recticlePosition, 1);

    }

}
