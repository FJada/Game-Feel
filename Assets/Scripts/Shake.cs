using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public float shakeMagnitude = 0;
    private float shakeDuration = 0;

    void Start()
    {
        shakeDuration = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Gain
            shakeMagnitude *= 1.1f;
            shakeDuration += Time.deltaTime;

        transform.localPosition = new Vector3(Random.value * shakeMagnitude, Random.value * shakeMagnitude, transform.localPosition.z);
    }

    public void ShakeMe(float time)
    {
        if (shakeMagnitude < 0.25f)
        {
            shakeMagnitude = 1/time * 0.03f;
        }
        else
        {
            shakeMagnitude = 0.25f;
        }
    }

    public void ShakeMeCam(float magnitude)
    {
        if (shakeMagnitude < 0.01f)
        {
            shakeMagnitude = 1/magnitude * 0.01f;
        }
        else
        {
            shakeMagnitude = 0.01f;
        }
    }
}
