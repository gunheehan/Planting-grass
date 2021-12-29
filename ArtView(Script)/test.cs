using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        coco();
    }

    IEnumerator coco()
    {
        print("coco1");

        yield return new WaitForSeconds(1.0f);

        print("coco2");
    }
}
