﻿#region

using UnityEngine;

#endregion

public class PlayerMovement : MonoBehaviour
{
    public float ForceStrength;
    public bool isNotPressed = false;

    public bool isPressed;

    public GameObject player;

    private readonly int RotSpeed = 150;

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        if (isPressed)
        {
            player.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * ForceStrength, ForceMode2D.Force);
            player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 0.02f, ForceMode2D.Impulse);
        }

        else if (!isPressed)
        {
            //nothing
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            player.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * ForceStrength, ForceMode2D.Force);
            player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 0.01f, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            player.GetComponent<Rigidbody2D>().AddRelativeForce(-Vector2.right * 0.2f, ForceMode2D.Force);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.acceleration.x < -0.15)
            player.transform.Rotate(Vector3.forward * RotSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.acceleration.x > 0.15)
            player.transform.Rotate(-Vector3.forward * RotSpeed * Time.deltaTime);
    }

    public void onPointerDownButton()
    {
        isPressed = true;
    }

    public void onPointerUpButton()
    {
        isPressed = false;
    }
}