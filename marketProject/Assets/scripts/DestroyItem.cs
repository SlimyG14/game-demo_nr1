using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("destroyItem");
    }

    private IEnumerator destroyItem()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
