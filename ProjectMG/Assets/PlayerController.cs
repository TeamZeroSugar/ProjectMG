using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Entity
{
    Rigidbody2D rigid2D;
    public float jumpForce = 800.0f;
    public float walkSpeed = 7.0f;
    public float maxVelocity = 7.0f;

    void Start()
    {
        Init(10, 10, 10, 10);
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    new private void Update()
    {
        base.Update();

        Vector2 moveVelocity = new Vector2(
            Input.GetAxisRaw("Horizontal") * walkSpeed, 
            Input.GetKeyDown(KeyCode.Space) && rigid2D.velocity.y == 0 ? jumpForce : 0);
        rigid2D.AddForce(moveVelocity);

        if (Input.GetKeyDown(KeyCode.Z)) {
            Debug.Log("a");
            useSkill(0); 
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = new Vector2(rigid2D.velocity.x, 0);
        if (velocity.sqrMagnitude > (maxVelocity * maxVelocity)) rigid2D.velocity = new Vector2(rigid2D.velocity.normalized.x * maxVelocity, rigid2D.velocity.y);
    }
}
