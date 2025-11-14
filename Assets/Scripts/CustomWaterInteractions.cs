using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomWaterInteractions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<SquidController>().hitWater = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Squid in Water");
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
            collision.gameObject.GetComponent<SquidController>().hitWater = false;
            Debug.Log("GScale: " + collision.gameObject.GetComponent<Rigidbody2D>().gravityScale);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Squid leaves Water");
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
            collision.gameObject.GetComponent<SquidController>().rb.velocity *= 2f;
            //collision.gameObject.GetComponent<SquidController>().hitWater = false;
            Debug.Log("GScale: " + collision.gameObject.GetComponent<Rigidbody2D>().gravityScale);
        }
    }
}
