using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMan : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player1;
    public Transform player2;
    public Transform player3;
    public Transform player4;

    public Vector3 cameraPos;

    public float minFOV = 40f;
    public float maxFOV = 70f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        float distance = Vector3.Distance(player1.position, player2.position);
        distance += Vector3.Distance(player1.position, player3.position);
        distance += Vector3.Distance(player1.position, player4.position);
        distance += Vector3.Distance(player2.position, player3.position);
        distance += Vector3.Distance(player2.position, player4.position);
        distance += Vector3.Distance(player3.position, player4.position);

        float averageDistance = distance / 6f;

        float t = Mathf.InverseLerp(0f, 100f, averageDistance);
        cam.fieldOfView = Mathf.Lerp(minFOV, maxFOV, t*5);


        cameraPos = new Vector3((player1.position.x + player2.position.x + player3.position.x + player4.position.x) / 4,
            40,
            ((player1.position.z + player2.position.z + player3.position.z + player4.position.z) / 4)-20);

        transform.position = cameraPos;

    }
}
