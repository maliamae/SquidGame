using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomWaterInteractions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponentInParent<SquidController>().hitWater = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("Squid in Water");
            collision.gameObject.GetComponentInParent<Rigidbody2D>().gravityScale = 0f;
            collision.gameObject.GetComponentInParent<SquidController>().hitWater = false;
            collision.gameObject.GetComponentInParent<SquidController>().inWater = true;
            //collision.gameObject.GetComponentInParent<SquidController>().hasSpedUp = false;
            //Debug.Log("GScale: " + collision.gameObject.GetComponentInParent<Rigidbody2D>().gravityScale);
            //Debug.Log(collision.gameObject.GetComponentInParent<SquidController>().rb.velocity);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector3 currentDir = collision.gameObject.GetComponentInParent<SquidController>().velocity.normalized;
            Vector3 airSpeed = new Vector3(5, 5, 0);
            

            if (collision.gameObject.GetComponentInParent<SquidController>().hasDashed == false)
            {
                currentDir.x *= 15;
                currentDir.y *= 12;
            }
            else
            {
                currentDir.x *= 25;
                currentDir.y *= 16;
            }
            
            //Debug.Log("Squid Velocity: " + currentDir);
            collision.gameObject.GetComponentInParent<Rigidbody2D>().gravityScale = 1f;
            //collision.gameObject.GetComponentInParent<SquidController>().rb.velocity *= 2f;
            collision.gameObject.GetComponentInParent<SquidController>().rb.AddForce(currentDir, ForceMode2D.Impulse);
            //collision.gameObject.GetComponentInParent<SquidController>().rb.AddForce(airSpeed, ForceMode2D.Force);
            collision.gameObject.GetComponentInParent<SquidController>().inWater = false;
            //Debug.Log("GScale: " + collision.gameObject.GetComponentInParent<Rigidbody2D>().gravityScale);
        }
    }
}
