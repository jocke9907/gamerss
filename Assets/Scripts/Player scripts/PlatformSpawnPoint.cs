using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnPoint : MonoBehaviour
{
    public static Vector3 platformSpawnPoint;

    private void Awake()
    {
        platformSpawnPoint= transform.position;
    }
}

