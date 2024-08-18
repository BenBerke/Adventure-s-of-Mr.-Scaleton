using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw_Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float yRange;
    [SerializeField] float xRange;
    [SerializeField] float startOffset;

    const float rotSpeed = 10f;

    Vector2 startPos;

    float r;
    float n;

    private void Start()
    {
        startPos = transform.position;
    }
    private void Update()
    {
        if (startOffset > 0)
        {
            startOffset -= 0.01f;
            return;
        }
        if (r > 360) r = 0;
        r += speed/100;
        n += rotSpeed;
        transform.rotation = Quaternion.Euler(15, 15, n);
        transform.position = new Vector2(startPos.x + Mathf.Sin(r) * xRange, startPos.y + Mathf.Sin(r) * yRange);
    }
}
