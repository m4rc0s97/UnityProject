using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWhole : MonoBehaviour
{
    // Start is called before the first frame update
    public float bulletLifeTime = 2;

    void Start()
    {
        StartCoroutine(DestroyAfterSeconds());
    }

    IEnumerator DestroyAfterSeconds()
    {
        yield return new WaitForSeconds(bulletLifeTime);
        
        Destroy(gameObject);
    }
}
