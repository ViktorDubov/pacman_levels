using System.Collections;
using System.Collections.Generic;

using static System.Math;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PacmanDirection : MonoBehaviour
{
    public float speed = 0.2f;
    public VariableJoystick variableJoystick;

    Vector2 dest = Vector2.zero;

    Vector2 startPos;
    Vector2 direction;
    bool directionChosen;

    //public levelgenerate levelgenerate;
    void Start()
    {
        dest = transform.position;
        direction = (Vector2)transform.position;
    }


    void FixedUpdate()
    {                  
            Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
            GetComponent<Rigidbody2D>().MovePosition(p);

            if (Abs(variableJoystick.Vertical) > 0.5 || Abs(variableJoystick.Horizontal) > 0.5)
            {
                if (Abs(variableJoystick.Vertical) > Abs(variableJoystick.Horizontal))
                {
                    if (variableJoystick.Vertical > 0)
                    {
                        direction = Vector2.up;
                    }
                    else
                    {
                        direction = Vector2.down;
                    }
                }
                else
                {
                    if (variableJoystick.Horizontal > 0)
                    {
                        direction = Vector2.right;
                    }
                    else
                    {
                        direction = Vector2.left;
                    }
                }
            }
            else
            {
                direction = Vector2.zero;
            }

            if (valid(direction))
            {
                dest = (Vector2)transform.position + 2.0f * direction;
            }

            Vector2 dir = dest - (Vector2)transform.position;
            GetComponent<Animator>().SetFloat("DirX", dir.x);
            GetComponent<Animator>().SetFloat("DirY", dir.y);   
    }

    bool valid(Vector2 dir)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + 1.5f * dir, pos);//при 2 застревает почему-то...
        return (hit.collider == GetComponent<Collider2D>());
    }
}
