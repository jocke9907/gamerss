using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlatformManager : MonoBehaviour
{

    //This scripts connects every platform with a particle system with the help of a list.

    List<GameObject> platforms = new List<GameObject>();
    List<Rigidbody> rbs = new List<Rigidbody>();
    List<ParticleSystem> particles = new List<ParticleSystem>();
    float particleTimer = 1.0f;
    float fallingTimer = 4.0f;
    int randomObj;
    float speedup = 0f;
    [SerializeField] SpawnPoint spawnPoint;
    AudioSource audio;

    //Adds 
    void Start()
    {
        audio = GetComponent<AudioSource>();
        foreach (Transform child in transform)
        {
            if (child.gameObject.tag == "Ground")
            {
                platforms.Add(child.gameObject);
            }
        }
        foreach (Transform child in transform)
        {
            if (child.gameObject.tag == "Particle")
            {

            }
        }


        for (int i = 0; i < platforms.Count; i++)
        {
            particles.Add(new ParticleSystem());
            particles[i] = platforms[i].GetComponentInChildren<ParticleSystem>();
            rbs.Add(new Rigidbody());
            rbs[i] = platforms[i].GetComponent<Rigidbody>();
        }
        randomObj = Random.Range(0, platforms.Count);
    }
}