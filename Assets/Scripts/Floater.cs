using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Floater : MonoBehaviour
{
    public float floatAmount = .5f;
    public float floatDuration = 2f;
    Tween t;
    void Start()
    {
        t = transform.DOMoveY(transform.position.y + floatAmount, floatDuration)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutQuad);
    }
    private void OnDestroy()
    {
        t?.Kill();
    }
}
