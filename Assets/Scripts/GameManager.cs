using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class GameManager : MonoBehaviour
{
    public GameObject mainMenu;
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
    public void StartButton()
    {
        mainMenu.GetComponent<CanvasGroup>().DOFade(0, 1f).SetEase(Ease.InQuart);
    }
}
