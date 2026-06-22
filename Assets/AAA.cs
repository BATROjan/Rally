using System.Collections;
using System.Collections.Generic;
using Terresquall;
using UnityEngine;
using UnityEngine.UI;

public class AAA : MonoBehaviour
{
    public float speed;
    public Text StepCountText;
    public VirtualJoystick joystick;

    private Rigidbody2D rb;
    public int CurrentTrigger;
    private int StepCount;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StepCount = 0;
        StepCountText.text = StepCount.ToString();
    }

    void FixedUpdate()
    {
        Vector2 moveDirection = new Vector2(joystick.GetAxis("Horizontal"), joystick.GetAxis("Vertical"));

        if (moveDirection.magnitude > 0.1f)
        {
            transform.up = moveDirection;
        }

        rb.AddForce(moveDirection * speed, ForceMode2D.Force);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var trigger = collision.GetComponent<TriggerScript>();
        if (trigger)
        {
            if (trigger.instance.TriggetNumber - CurrentTrigger == 1)
            {
                CurrentTrigger = trigger.instance.TriggetNumber;
                if (CurrentTrigger == 6)
                {
                    CurrentTrigger = 0;
                    StepCount++;
                    StepCountText.text = StepCount.ToString();
                }
            }
        }
    }
}