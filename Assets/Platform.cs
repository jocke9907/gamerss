using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] SpawnPoint spawn;
    [SerializeField] Rigidbody rb;
    [SerializeField] ParticleSystem particles;
    bool timerStarted = false;
    double timerMax = 2;
    // Start is called before the first frame update
    void Start()
    {
        spawn = FindObjectOfType<SpawnPoint>();
        if (spawn == null)
            Debug.LogError("SpawnPoint not found in the scene!");
        
        particles = GetComponentInChildren<ParticleSystem>();
        if (particles == null)
            Debug.LogError("particles not found");
    }

    // Update is called once per frame
    void Update()
    {  
            if(timerStarted)
                timerMax -= Time.deltaTime;
            
            if(timerMax < 0)
                rb.useGravity = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (spawn.gameStarted)
        {
            if (other.gameObject.CompareTag("Player"))
                particles.Play();   
                timerStarted= true;

        }
        
    }



}
