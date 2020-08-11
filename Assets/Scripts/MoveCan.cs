using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCan : MonoBehaviour
{
    [SerializeField] float movementFactor = 2f;
    [SerializeField] float maxPos;
    private float verticalPosChange;
    private float initialVerticalPosition;
    void Start()
    {
        initialVerticalPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        verticalPosChange = Mathf.PingPong(Time.time * movementFactor, maxPos) + initialVerticalPosition;
        transform.position = new Vector3(transform.position.x, verticalPosChange, transform.position.z);
    }
}
