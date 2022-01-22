using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;
public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public GameObject mainMenu;
    public GameObject endMenu;
    public Text scoreText;
    [HideInInspector]
    public int currentPoint;
    public UnityAction restartGame;
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
    public void StartButton()
    {
        mainMenu.GetComponent<CanvasGroup>().DOFade(0, 1f).SetEase(Ease.InQuart).OnComplete(()=> 
        {
            mainMenu.gameObject.SetActive(false);
        });
    }
    public void EndGame()
    {
        endMenu.gameObject.SetActive(true);
        endMenu.GetComponent<CanvasGroup>().DOFade(1, 1f).SetEase(Ease.InQuart);
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        currentPoint = 0;
        scoreText.text = "";
        endMenu.GetComponent<CanvasGroup>().DOFade(0, 1f).SetEase(Ease.InQuart).OnComplete(() =>
        {
            restartGame?.Invoke();
            endMenu.gameObject.SetActive(false);
        });
    }
}
