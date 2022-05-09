using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    protected Collider2D skillCollider;
    protected SpriteRenderer skillRenderer;
    protected Entity caster = null;

    public int requireHP;
    public int requireMP;

    public float startDelay;
    public float endDelay;

    public bool isRunning
    {
        get
        {
            return caster != null;
        }
    }

    protected void Start()
    {
        skillCollider = GetComponent<Collider2D>();
        skillRenderer = GetComponent<SpriteRenderer>();
        skillCollider.isTrigger = true;
        skillCollider.enabled = false;
        skillRenderer.enabled = false;
    }

    public IEnumerator useSkill(Entity _caster)
    {
        caster = _caster;

        yield return new WaitForSeconds(startDelay);
        skillCollider.enabled = true;
        skillRenderer.enabled = true;

        yield return new WaitForSeconds(endDelay);
        skillCollider.enabled = false;
        skillRenderer.enabled = false;

        caster = null;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Entity>() != null && collision.GetComponent<Entity>() != caster) 
            invoke(collision.GetComponent<Entity>());
    }

    public abstract void invoke(Entity target);
}
