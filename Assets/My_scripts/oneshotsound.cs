using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneshotsound : MonoBehaviour
{
    [SerializeField]
    GameObject sound;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            sound.gameObject.SetActive(true);
            Destroy(gameObject, 7);
        }
    }
}
