using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInputController : MonoBehaviour
{
    [SerializeField] ParticleSystem _BulletSpawner;
    [SerializeField] AudioSource _AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (_BulletSpawner)
            {
                _BulletSpawner.Play();
                _AudioSource.Play();
            }
           
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (_BulletSpawner)
            {
                _BulletSpawner.Stop();
                _AudioSource.Stop();
            }
              
        }
    }
}
