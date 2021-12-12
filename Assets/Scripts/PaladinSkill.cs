using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaladinSkill : Skill
{
    public override void SkillTrigger()
    {
        Debug.Log("Èú");
        gameObject.GetComponent<Paladin>().currentHp += 50;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
