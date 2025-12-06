using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.InputSystem;

public class CrossFadeImage : MonoBehaviour
{
    public bool isButton;
    public CanvasGroup crossFade;
    //public GameObject player;
    //public PlayerInput playerIn;

    private void Start()
    {
        StartCoroutine(AnimateOut());
    }
    public IEnumerator AnimateIn()
    {
        if (this.gameObject.activeSelf == false)
        {
            this.gameObject.SetActive(true);
        }

        var tweener = crossFade.DOFade(1f, 1f);
        yield return tweener.WaitForCompletion();
        yield return new WaitForSeconds(.5f);
        StartCoroutine(AnimateOut());
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