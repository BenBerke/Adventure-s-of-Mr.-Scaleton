using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_Spin : MonoBehaviour
{
    [SerializeField] float speed;
    float r;
    private void FixedUpdate()
    {
        r += speed/100;
        if (r >= 360) r = 0;

        transform.rotation = Quaternion.Euler(15, 15, r);
    }
}
