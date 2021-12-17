using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject _hero;
    void Start()
    {
        transform.position = new Vector3(_hero.transform.position.x, _hero.transform.position.y, transform.position.z);
    }


    void Update()
    {

    }
}
