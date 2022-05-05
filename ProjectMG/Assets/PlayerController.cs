using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
 Rigidbody2D rigid2D;
 float jumpForce = 800.0f;
 float walkSpeed = 7.0f;
 // Start is called before the first frame update
 void Start()
 {
  this.rigid2D = GetComponent<Rigidbody2D>();
 }

 // Update is called once per frame

 private void Update()
 {
  if (Input.GetKeyDown(KeyCode.Space) && rigid2D.velocity.y == 0)
  {
   Debug.Log("Jump");
   this.rigid2D.AddForce(transform.up * this.jumpForce);
  }

  Vector3 moveVelocity = Vector3.zero;
  if (Input.GetKey(KeyCode.RightArrow))
  {
   moveVelocity = Vector3.right;
  }
  if (Input.GetKey(KeyCode.LeftArrow))
  {
   moveVelocity = Vector3.left;
  }
  transform.position += moveVelocity * walkSpeed * Time.deltaTime;

 }
}
