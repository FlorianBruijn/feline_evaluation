using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_flo : MonoBehaviour
{
    private Quaternion _lookRotation;
    public Transform planet;
    private Vector3 _direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotation to planet
        _direction = (planet.position - transform.position).normalized;
        _lookRotation = Quaternion.LookRotation(_direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, 1);
    }
}
