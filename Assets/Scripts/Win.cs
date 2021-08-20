using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    Material mat;

    int i=0;
    GameObject deneme;
    void Start()
    {
        mat=GetComponent<Material>();
    }

    void Update()
    {
        if (i < 4)
        {
            deneme = GameManager.Instance.BallList1[i];
            i++;
            print(deneme);
        }
    }
}
