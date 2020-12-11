using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  RotateManager : MonoBehaviour {

    public float speed = 10f;

    void Start()
    {
        
    }

    void Update()
    {
         transform.Rotate(0, 0, -1);
    }
}
