using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    public bool destroy = false;

    private void Update()
    {
        if (destroy)
        {
            StartCoroutine(SelfDestruct());
        }
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
