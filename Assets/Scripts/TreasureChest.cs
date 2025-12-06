using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreasureChest : MonoBehaviour
{
    public int targetScene;
    public CrossFadeImage blackScreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Transition());
        }
    }

    public IEnumerator Transition()
    {
        StartCoroutine(blackScreen.AnimateIn());
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(targetScene);
    }
}
