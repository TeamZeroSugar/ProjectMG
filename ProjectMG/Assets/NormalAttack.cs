using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttack : MonoBehaviour
{
 float speed = 0.3f;
 float dir = 0;
 float range = 10.0f;
 // Start is called before the first frame update
 void Start()
 {
    
 }
 public void StartSetting(int dir, Vector3 Pos)
 {
  this.transform.position = Pos;
  this.dir = dir;
 }

 // Update is called once per frame
 void FixedUpdate()
 {
  if (range <= 0) Destroy(gameObject);
  this.transform.Translate(new Vector3(speed*dir, 0, 0));
  range -= speed;
 }

 private void OnTriggerEnter2D(Collider2D collision)
 {
  if(collision.tag=="Enemy"||collision.tag== "Structure")
  {
  Destroy(gameObject);
   if(collision.tag=="Enemy")
   {
    
   }
  }
 }
 private void OnBecameInvisible()
 {
  Destroy(gameObject);
 }
}
