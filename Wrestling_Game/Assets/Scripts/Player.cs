using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform hand;
    public float hitDeg = 10f;
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0)) Hit();
    }

    private void Hit()
    {
        hand.Rotate(0,0,hitDeg);
    }
}
