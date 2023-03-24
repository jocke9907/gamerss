using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerBox : MonoBehaviour
{
    int placement = 1;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("This player died " + placement);
            placement = placement + 1;
        }
    }
}