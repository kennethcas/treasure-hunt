using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRoomba : MonoBehaviour
{

    public float speed = 5.0f;
    public float raycastDistance = 3.0f;
    //public bool movingLeft = true;
    //public bool movingUp = false;
    Vector2 direction = Vector2.right;
    public bool changedirection = false;

    void MoveRoomba()
    {

        //if (movingLeft)
        //    direction = Vector2.left;
        //else if (!movingLeft)
        //    direction = Vector2.right;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, raycastDistance);

        if (hit.collider != null)
        {
            changedirection = true;
        }

        if (changedirection)
        {
            if (direction == Vector2.right || direction == Vector2.left)
            {
                RaycastHit2D up = Physics2D.Raycast(transform.position, Vector2.up, raycastDistance);
                if (up.collider != null) direction = Vector2.down;
                else direction = Vector2.up;
            }
            else if (direction == Vector2.up || direction == Vector2.down)
            {
                RaycastHit2D left = Physics2D.Raycast(transform.position, Vector2.left, raycastDistance);
                if (left.collider != null) direction = Vector2.right;
                else direction = Vector2.left;
            }
            changedirection = false;
        }
        else
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }

    }

    private void Update()
    {

        MoveRoomba();

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, direction * raycastDistance);
    }

}

    
