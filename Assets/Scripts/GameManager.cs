using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;
public class GameManager : MonoBehaviourSingleton<GameManager>
{
    [HideInInspector]
    public int currentPoint;
    public GameObject mainMenu;
    public GameObject endMenu;
    public Text scoreText;
    public int initialCollectibleCount;
    public UnityAction restartGame;
    private GameObject collectible;
    public Vector2 spawnableWidth;
    public Vector2 spawnableHeight;
    
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
    private void Start()
    {
        collectible = Resources.Load<GameObject>("Prefabs/Collectible");
        SpawnCollectibles();
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
    private void SpawnCollectibles()
    {
        for(int i = 0; i < initialCollectibleCount; i++)
        {
            var width = Random.Range(spawnableWidth.x, spawnableWidth.y);
            var height = Random.Range(spawnableHeight.x, spawnableHeight.y);
            Instantiate(collectible, new Vector3(width, 1, height), transform.rotation);
        }
    }
}
