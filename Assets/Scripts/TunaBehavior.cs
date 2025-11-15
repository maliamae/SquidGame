using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunaBehavior : MonoBehaviour
{
    public float moveSpeed = 5f;

    

    private void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
        //Debug.Log("tuna collides");
    }

}
