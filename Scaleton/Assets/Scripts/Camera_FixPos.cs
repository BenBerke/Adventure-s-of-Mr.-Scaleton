using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_FixPos : MonoBehaviour
{
    [SerializeField] Vector2 fixCamPos;
    private void Update()
    {
        transform.position = new Vector3(fixCamPos.x, fixCamPos.y, -10);
    }
}
