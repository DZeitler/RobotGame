using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInputController : MonoBehaviour
{
    [SerializeField] ParticleSystem _BulletSpawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_BulletSpawner)
            {
                _BulletSpawner.Play();
            }
           
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (_BulletSpawner)
            {
                _BulletSpawner.Stop();
            }
              
        }
    }
}
