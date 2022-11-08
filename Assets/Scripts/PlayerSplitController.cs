using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSplitController : MonoBehaviour
{
    [SerializeField] GameObject bluePlayer, bluePlatformGenerator, mainCamera, hidingBox;
    [SerializeField] Transform oneCubePosition;
    [SerializeField] Score scoreScript;
    [SerializeField] int pointsToSplit = 100;

    [SerializeField] AudioClip spawnAudioClip;
    AudioSource audioSource;

    [SerializeField] Animator arrowKeysAnimator;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        mainCamera.transform.position = oneCubePosition.position;
        mainCamera.GetComponent<Animator>().SetBool("split", false);
        hidingBox.SetActive(true);
        bluePlayer.SetActive(false);
        bluePlatformGenerator.SetActive(false);        
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreScript.score >= pointsToSplit)
        {
            StartCoroutine(Split());
        }
    }

    IEnumerator Split()
    {
        mainCamera.GetComponent<Animator>().SetBool("split", true);
        yield return new WaitForSeconds(0.5f);
        arrowKeysAnimator.SetBool("dualIn", true);
        audioSource.PlayOneShot(spawnAudioClip);
        hidingBox.GetComponent<Animator>().SetBool("hideBox", true);
        yield return new WaitForSeconds(1f);
        hidingBox.SetActive(false);
        bluePlayer.SetActive(true);
        bluePlatformGenerator.SetActive(true);
    }
}
