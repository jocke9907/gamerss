using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlatformManager : MonoBehaviour
{

    List<GameObject> platforms = new List<GameObject>();
    List<Rigidbody> rbs = new List<Rigidbody>();
    List<ParticleSystem> particles = new List<ParticleSystem>();
    float particleTimer = 3.0f;
    float fallingTimer = 5.0f;
    int randomObj;
    float speedup = 0f;
    [SerializeField] SpawnPoint spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {
        if (spawnPoint.gameStarted)
        {
            fallingTimer -= Time.deltaTime;
            particleTimer -= Time.deltaTime;

            if (fallingTimer <= 0.0f)
            {
                fallingTimer = 5.0f - speedup;
                rbs[randomObj].useGravity = true;
                randomObj = Random.Range(0, platforms.Count);
                particles[randomObj].Play();

                if (speedup <= 3.0f)
                {
                    speedup = speedup + 0.5f;
                }
            }
        }


    }
}