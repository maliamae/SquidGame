using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidRespawn : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject squidObject;
    public int deaths = 0;

    private void Update()
    {
        if (squidObject.activeSelf == false)
        {
            deaths++;

            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1.5f);
        squidObject.transform.position = spawnPoint.transform.position;
        squidObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
        squidObject.SetActive(true);
        squidObject.transform.GetChild(0).gameObject.SetActive(true);
    }

}
