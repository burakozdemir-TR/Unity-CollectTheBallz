using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    protected Joystick joystick;
    private Rigidbody rb;
    private Vector3 startPosition;
    private Vector3 startRotation;
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        rb = GetComponent<Rigidbody>();
        startPosition = gameObject.transform.position;
        startRotation = gameObject.transform.eulerAngles;
        GameManager.Instance.restartGame += RestartPlayerPosition;
    }
    void Update()
    {
        PlayerMovement();
    }
    private void PlayerMovement()
    {
        rb.velocity = new Vector3(joystick.Horizontal * 10f, 0, joystick.Vertical * 10f);
        if (rb.velocity != Vector3.zero)
            gameObject.transform.rotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!(other.tag == "Collectible"))
            return;
        GameManager.Instance.Collect(other);
    }
    private void RestartPlayerPosition()
    {
        gameObject.GetComponent<Transform>().DOMove(startPosition, 1.5f).SetEase(Ease.InBack).OnComplete(()=> 
        {
            gameObject.GetComponent<Transform>().DORotate(startRotation, 1.5f).SetEase(Ease.OutBack).OnComplete(() =>
            {
                GameManager.Instance.currentPoint = 0;
                GameManager.Instance.scoreText.text = "";
            });
        });
    }
}
