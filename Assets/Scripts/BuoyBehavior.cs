using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuoyBehavior : MonoBehaviour
{
    public GameObject spawnPoint;

    public Transform spawnOffset;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            spawnPoint.transform.position = spawnOffset.position;
            Debug.Log("buoy check");
        }
    }
}
