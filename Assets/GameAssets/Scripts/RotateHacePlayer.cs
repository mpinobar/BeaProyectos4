using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHacePlayer : MonoBehaviour
{
    Vector3 lookPos;
    Quaternion rotation;
    [SerializeField] Transform tarject;
    [SerializeField] float rotationDamping;
    private void Update()
    {
        lookPos = tarject.position - transform.position;
        lookPos.y = 0;
        rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);

    }
}
