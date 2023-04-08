using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{

    public float rotationSpeed = 1.0f;
    private Quaternion startRotation;
    private Quaternion targetRotation;

    void Start()
    {
        startRotation = transform.rotation;
        targetRotation = startRotation * Quaternion.Euler(0, 0, 90);
        StartCoroutine(RotateEveryFiveSeconds());
    }

    IEnumerator RotateEveryFiveSeconds()
    {
        while (true)
        {
            float elapsedTime = 0.0f;
            while (elapsedTime < 5.0f)
            {
                transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime / 5.0f);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            transform.rotation = targetRotation;
            startRotation = targetRotation;

            // Pause for five seconds
            yield return new WaitForSeconds(5.0f);

            // Set the new target rotation
            targetRotation *= Quaternion.Euler(0, 0, 90);
        }
    }
}
