using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindCurrentBehavior : MonoBehaviour
{
    public Vector2 currentVel;
    public Vector3 newVel;
    public Vector3 targetVel;
    private Rigidbody2D playerRB;
    public AudioSource windAudio;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerRB = collision.gameObject.GetComponentInParent<Rigidbody2D>();

            currentVel = collision.gameObject.GetComponentInParent<SquidController>().rb.velocity;

            //Debug.Log("whoosh");
            windAudio.Play();

            newVel = new Vector3(currentVel.x * 1.25f, -currentVel.y, 0);
            targetVel = new Vector3(newVel.x, 0f, 0f);

            //collision.gameObject.GetComponentInParent<SquidController>().rb.AddForce(newVel, ForceMode2D.Impulse);

            /*

            if (collision.gameObject.transform.position.y < this.GetComponentInParent<Transform>().position.y)
            {
                currentVel = collision.gameObject.GetComponentInParent<SquidController>().rb.velocity;
                
                Debug.Log("whoosh");
                newVel = new Vector3(currentVel.x * 1.25f, -currentVel.y, 0);

                collision.gameObject.GetComponentInParent<SquidController>().rb.AddForce(newVel, ForceMode2D.Impulse);
                //StartCoroutine(FloatFall());
            }
            */

        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (newVel != null)
            {
                //Vector2 floatVel = new Vector3(newVel.x, 0f);
                //collision.gameObject.GetComponentInParent<SquidController>().rb.velocity = new Vector2(newVel.x, 0f);
                //playerRB.velocity = new Vector2(playerRB.velocity.x * 1.005f, 0f);

                //squidSprite.transform.right = Vector3.Lerp(squidSprite.transform.right, rb.velocity, rotationSpeed * Time.deltaTime);
                //collision.gameObject.GetComponentInParent<SquidController>().rb.velocity = Vector2.Lerp(collision.gameObject.GetComponentInParent<SquidController>().rb.velocity, );
                playerRB.velocity = Vector2.Lerp(playerRB.velocity, targetVel, 15f * Time.deltaTime);
            }

        }
    }

    IEnumerator FloatFall()
    {
        float t = 0f;

        while (t < 2f)
        {
            playerRB.velocity = new Vector2(newVel.x, 0f);
            t += Time.deltaTime;
            yield return null;
        }
        //velocity = new Vector3(velocity.x * 1.25f, -velocity.y, 0);
        //rb.AddForce(newVel, ForceMode2D.Impulse);
        

        playerRB.velocity = currentVel;
    }
    
}
