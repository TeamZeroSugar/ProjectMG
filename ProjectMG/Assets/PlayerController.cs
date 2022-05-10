using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Entity
{
    Rigidbody2D rigid2D;
    GameObject normalAttack;
    public float jumpForce = 750.0f;
    public float walkSpeed = 20.0f;
    public float maxVelocity = 0.0f;
    private int dir = 1;
    private float normalAttackTimer = 0.0f;
    private float normalAttackDelay = 0.5f;
    private bool isNormalAttackAble = true;

    void Start()
    {
        Init(10, 10, 10, 10);
        this.rigid2D = GetComponent<Rigidbody2D>();
        normalAttack = GameObject.Find("NormalAttackGenerator");
    }

    new private void Update()
    {
        base.Update();

        Vector2 moveVelocity = new Vector2(
            Input.GetAxisRaw("Horizontal") * walkSpeed,
            Input.GetKeyDown(KeyCode.Space) && rigid2D.velocity.y == 0 ? jumpForce : 0);
        rigid2D.AddForce(moveVelocity);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("a");
            useSkill(0);
        }

        if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Horizontal") != dir) dir = (int)Input.GetAxisRaw("Horizontal");

        Shooting();
    }

    private void FixedUpdate()
    {
        Vector2 velocity = new Vector2(rigid2D.velocity.x, 0);
        if (velocity.sqrMagnitude > (maxVelocity * maxVelocity)) rigid2D.velocity = new Vector2(rigid2D.velocity.normalized.x * maxVelocity, rigid2D.velocity.y);
    }

    private void Shooting()
    {
        if (!isNormalAttackAble) normalAttackTimer += Time.deltaTime;
        if (normalAttackTimer >= normalAttackDelay)
        {
            isNormalAttackAble = true;
            normalAttackTimer = 0.0f;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) && isNormalAttackAble)
        {
            normalAttack.GetComponent<NormalAttackGenerator>().Generate(dir, this.transform.position);
            isNormalAttackAble = false;
        }
    }
}
