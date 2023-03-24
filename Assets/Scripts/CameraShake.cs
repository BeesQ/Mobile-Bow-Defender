using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private static Vector3 initialPosition;
    private static float shakeMagnitude = 0f;
    private static float shakeDuration = 0f;

    private void Awake()
    {
        if (Helpers.Camera != null)
        {
            initialPosition = transform.localPosition;
        }
    }

    public static void ShakeCamera(float magnitude, float duration)
    {
        shakeMagnitude = magnitude;
        shakeDuration = duration;
        Instance.StartCoroutine(Shake());
    }

    private static CameraShake Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CameraShake>();
            }
            return instance;
        }
    }

    private static CameraShake instance;

    private static IEnumerator Shake()
    {
        float elapsed = 0.0f;
        while (elapsed < shakeDuration)
        {
            float x = initialPosition.x + Random.Range(-1f, 1f) * shakeMagnitude;
            float y = initialPosition.y + Random.Range(-1f, 1f) * shakeMagnitude;
            Instance.transform.localPosition = new Vector3(x, y, initialPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        Instance.transform.localPosition = initialPosition;
    }
}