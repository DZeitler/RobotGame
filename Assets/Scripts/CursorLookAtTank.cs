using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLookAtTank : MonoBehaviour
{

    [SerializeField] private Transform _tank;
    private Transform _cursor;
    // Start is called before the first frame update
    void Start()
    {
        _cursor = transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 LookPos = _cursor.position - _tank.position;
        _cursor.rotation = Quaternion.LookRotation(LookPos);
    }
}
