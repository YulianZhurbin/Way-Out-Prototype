using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTerminatorActivator : MonoBehaviour
{
    [SerializeField] GameObject gameTerminator;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("GameTerminatorActivator.OnTriggerEnter()");
        if(other.CompareTag("Player"))
        {
            gameTerminator.SetActive(true);
        }
    }
}
