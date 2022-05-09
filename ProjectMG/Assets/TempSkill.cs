using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempSkill : Skill
{
    new protected void Start()
    {
        base.Start();

        requireHP = 1;
        requireMP = 1;

        startDelay = 0f;
        endDelay = 0.1f;
    }

    public override void invoke(Entity target)
    {
        target.EditHP(-10);
    }
}
