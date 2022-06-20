using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    [SerializeField] Transform tarject;
    [SerializeField] Vector3 offset;
    [SerializeField] float damping;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(tarject);

        float posX = Mathf.Lerp(transform.position.x, tarject.position.x + offset.x, Time.deltaTime * damping);
        float posY = Mathf.Lerp(transform.position.y, tarject.position.x + offset.y, Time.deltaTime * damping);
        float posZ = Mathf.Lerp(transform.position.z, tarject.position.x + offset.z, Time.deltaTime * damping);

        transform.position = new Vector3(posX, posY, posZ);
    }
}
