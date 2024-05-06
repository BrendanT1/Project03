using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDuplicator : MonoBehaviour
{
    public GameObject obj;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            InstObj();
        }
    }

    void InstObj()
    {
        int i = 0;
        while (i < 2)
        {
            Instantiate(obj, new Vector3(Random.Range(-20f, 20f), 0f, Random.Range(-20f, 20f)), Quaternion.identity);
            i++;
        }
    }
}
