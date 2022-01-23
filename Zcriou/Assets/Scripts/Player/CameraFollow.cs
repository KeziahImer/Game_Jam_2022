using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        MoveTowardsTarget();
    }

    private void MoveTowardsTarget()
    {
        transform.position = new Vector3 (player.position.x, player.position.y, -5);
    }
}
