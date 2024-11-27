using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine.UIElements;
using System.Threading;
using System.Threading.Tasks;

public class CubeRotationAsync : MonoBehaviour
{
    CancellationTokenSource cts;
    CancellationToken token;
    public void StartRotating()
    {
        cts = new CancellationTokenSource();
        token = cts.Token;

        Task task = Rotate(token);
    }

    public void StopRotating() => cts.Cancel();

    async Task Rotate(CancellationToken token)
    {
        print("rentre");
        float endTime = Time.time + 5;
        while (Time.time < endTime)
        {
            token.ThrowIfCancellationRequested();
            transform.Rotate(new Vector3(0, 20, 0) * Time.deltaTime);
            await UniTask.Yield();
        }
    }
}
