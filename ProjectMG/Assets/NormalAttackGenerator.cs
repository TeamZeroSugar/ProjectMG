using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAttackGenerator : MonoBehaviour
{
 // Start is called before the first frame update
 public GameObject normalAttackPrefab;
    void Start()
    {
        
    }
 public void Generate(int dir, Vector3 Pos)
 {
  GameObject NA = Instantiate(normalAttackPrefab) as GameObject;
  NA.GetComponent<NormalAttack>().StartSetting(dir,Pos);

  //NA.startSetting(dir);
 }
 // Update is called once per frame
 void Update()
    {
        
    }
}
