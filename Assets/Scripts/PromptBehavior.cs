using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptBehavior : MonoBehaviour
{
    public bool isButton;
    public CanvasGroup crossFade;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //this.gameObject.SetActive(false);
            StartCoroutine(AnimateOut());
        }
    }

    public IEnumerator AnimateOut()
    {
        var tweener = crossFade.DOFade(0f, 1f);
        yield return tweener.WaitForCompletion();

        if (isButton)
        {
            this.gameObject.SetActive(false);
        }

    }
}
