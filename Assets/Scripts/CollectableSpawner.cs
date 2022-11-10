using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{

    ObjectPooler objectpooler;

    private void Start()
    {
        objectpooler = ObjectPooler.Instance;
    }
    private void FixedUpdate()
    {
        ObjectPooler.Instance.SpawnFromPool("Heart", transform.position);
        ObjectPooler.Instance.SpawnFromPool("Diamond", transform.position);
        ObjectPooler.Instance.SpawnFromPool("Star", transform.position);
    }
}
