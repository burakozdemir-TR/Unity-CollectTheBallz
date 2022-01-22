using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectibleController : MonoBehaviour
{
    private Sequence sequence;
    void Start()
    {
        StartCoroutine(PlayCollectibleAnimation());
    }
    private IEnumerator PlayCollectibleAnimation()
    {
        var playerTransform = gameObject.GetComponent<Transform>();    
        Tween initialTween = playerTransform.DOMoveY(.5f, 1f);

        yield return initialTween.WaitForCompletion();

        DOTween
            .Sequence()
            .Append
            (
                playerTransform.DOMoveY(1, 1f).SetEase(Ease.InQuad)
            )
            .Append
            (
                playerTransform.DOMoveY(.5f, 1f).SetEase(Ease.OutQuad)
            )
            .SetLoops(-1);

        yield return 0f;
    }
}
