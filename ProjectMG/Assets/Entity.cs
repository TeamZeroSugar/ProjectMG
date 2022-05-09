using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    protected int maxHP, maxMP;
    protected int HP, MP;

    public List<Skill> skills;

    public void Init(int _maxHP, int _maxMP, int defaultHP, int defaultMP)
    {
        maxHP = _maxHP;
        maxMP = _maxMP;
        HP = Mathf.Min(defaultHP, maxHP);
        MP = Mathf.Min(defaultMP, maxMP);

        for (int i = 0; i < skills.Count; i++)
        {
            Skill tmpObject = Instantiate(skills[i], transform.position + skills[i].transform.localPosition, Quaternion.identity);

            skills[i] = tmpObject;
            tmpObject.transform.SetParent(transform);
        }
    }

    public void Update()
    {
        if (HP <= 0) Destroy(gameObject);
    }

    public void EditHP(int value)
    {
        HP += value;
    }

    public void useSkill(int skillIndex)
    {
        if (skills.Count > skillIndex && skills[skillIndex] != null && !skills[skillIndex].isRunning)
        {
            if (MP >= skills[skillIndex].requireMP)
            {
                MP -= skills[skillIndex].requireMP;
                StartCoroutine(skills[skillIndex].useSkill(this));
            }
            else if (HP > skills[skillIndex].requireHP)
            {
                HP -= skills[skillIndex].requireHP;
                StartCoroutine(skills[skillIndex].useSkill(this));
            }
            else
            {
                Debug.Log("Not Enough HP");
            }
        }
    }
}
