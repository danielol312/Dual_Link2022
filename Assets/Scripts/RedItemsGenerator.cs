using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedItemsGenerator : MonoBehaviour
{

   // public Transform position;
    public GameObject[] itemsToInstantiate;
    [SerializeField] float secondSpawn = 3f;
    [SerializeField] float minPosX;
    [SerializeField] float maxPosX;
    [SerializeField] float minPosY;
    [SerializeField] float maxPosY;
    // Start is called before the first frame update
    public void Start()
    {
        StartCoroutine("ItemInvocation");
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    IEnumerator ItemInvocation()
    {
        while (true)
        {
            int randomNumber = Random.Range(0, itemsToInstantiate.Length);
            var wantedX = Random.Range(minPosX, maxPosX);
            var wantedY = Random.Range(minPosY, maxPosY);
            var position = new Vector3(wantedX, wantedY );
            GameObject item = Instantiate(itemsToInstantiate[randomNumber],position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            if (item != null)
            {
                Destroy(item);
            }
            
        }
    }
}
