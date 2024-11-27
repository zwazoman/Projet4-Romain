using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    Coroutine coroutine;

    public void StartRotating() => coroutine = StartCoroutine(Rotate());
    public void StopRotating() => StopCoroutine(coroutine);

    IEnumerator Rotate()
    {
        float endTime = Time.time + 5;
        while (Time.time < endTime)
        {
            transform.Rotate(new Vector3(0,20,0) * Time.deltaTime);
            yield return null;
        }
    }
}
