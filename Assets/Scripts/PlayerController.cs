using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected Joystick joystick;
    private Rigidbody rb;
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        PlayerMovement();
    }
    private void PlayerMovement()
    {
        rb.velocity = new Vector3(joystick.Direction.x * 10f , rb.velocity.y, joystick.Direction.y * 10f);
    }
}
