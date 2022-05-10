using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
 Rigidbody2D rigid2D;

 float hp = 300.0f;
 int manaStack = 0;

 //manaSphere
 GameObject mana;

 // Start is called before the first frame update
 void Start()
 {
  this.rigid2D = GetComponent<Rigidbody2D>();
 }

 // Update is called once per frame
 void Update()
 {

 }

 public void DamageByType(string type, float damage)
 {
  switch (type)
  {
   case"normal":
    manaStack++;
    hp -= damage;
    if(manaStack==3)
    {
     GenerateManaSphere(1, 1);
     manaStack = 0;
    }
  break;
  }
 }
 void GenerateManaSphere(float count, float size)
 {
  for(int i=0;i<count;i++)
  {
  }
 }
}
