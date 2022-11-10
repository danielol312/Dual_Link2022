using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour, IpooledObject
{
    public float upforce = 1f;
    public float sideforce = .1f;
    // Start is called before the first frame update
    public void OnObjectSpawn()
    {
        float xforce= Random.Range(-sideforce, sideforce);
        float yforce = Random.Range(upforce/2f , upforce);
        float zforce = Random.Range(-sideforce, sideforce);

        Vector3 force=new Vector3(xforce,yforce,zforce);

        GetComponent<Rigidbody>().velocity=force;
    }

    
}
