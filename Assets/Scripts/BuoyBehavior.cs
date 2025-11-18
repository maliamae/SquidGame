using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuoyBehavior : MonoBehaviour
{
    public GameObject spawnPoint;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            spawnPoint.transform.position = this.transform.position;
            Debug.Log("buoy check");
        }
    }
}
