using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerofcamera : MonoBehaviour
{
    public levelgenerate levelgenerate;
    GameObject player;
    Vector3 differenceofposition;
    void Start()
    {
        if (!levelgenerate.pacmanisdestroyed)
        {
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
                transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, -5f), 0.1f * Time.fixedTime);
                differenceofposition = transform.position - player.transform.position;
            }
        }
        //if (player==null)
        //{
        //    player = GameObject.FindGameObjectWithTag("Player");
        //    transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, 0f), 2f*Time.deltaTime);
        //    differenceofposition = transform.position - player.transform.position;
        //}
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!levelgenerate.pacmanisdestroyed)
        {
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
                transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, -5f), 0.1f * Time.fixedTime);
                differenceofposition = transform.position - player.transform.position;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, differenceofposition + player.transform.position, 0.1f*Time.fixedTime);
            }
        }

        
    }
}
