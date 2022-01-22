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
    public int count = 0;


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
            Counter(1);
        }
    }
    private int Counter(int counter = 0)
    {
        return count += counter;
    }
    public void Collect(Collider other)
    {
        var collectible = other.gameObject;
        currentPoint += collectible.GetComponent<CollectibleController>().point;
        scoreText.text = ($"Score : { currentPoint}");
        Destroy(collectible);
        initialCollectibleCount = 1;
        SpawnCollectibles();
        if (currentPoint == 100)
            EndGame();
    }
}
