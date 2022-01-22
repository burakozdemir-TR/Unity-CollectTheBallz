using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    public Collectible collectible;
    [HideInInspector]
    public int point;
    void Start()
    {
        point = collectible.point;
    }
}
