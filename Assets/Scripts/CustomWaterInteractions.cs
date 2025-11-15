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
            Debug.Log("Squid in Water");
            collision.gameObject.GetComponentInParent<Rigidbody2D>().gravityScale = 0f;
            collision.gameObject.GetComponentInParent<SquidController>().hitWater = false;
            collision.gameObject.GetComponentInParent<SquidController>().inWater = true;
            Debug.Log("GScale: " + collision.gameObject.GetComponentInParent<Rigidbody2D>().gravityScale);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Squid leaves Water");
            collision.gameObject.GetComponentInParent<Rigidbody2D>().gravityScale = 1f;
            //collision.gameObject.GetComponentInParent<SquidController>().rb.velocity *= 2f;
            collision.gameObject.GetComponentInParent<SquidController>().rb.AddForce(new Vector3(25, 10, 0), ForceMode2D.Impulse);
            collision.gameObject.GetComponentInParent<SquidController>().inWater = false;
            Debug.Log("GScale: " + collision.gameObject.GetComponentInParent<Rigidbody2D>().gravityScale);
        }
    }
}
