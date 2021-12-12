using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardSkill : Skill
{
    int originalAttack;
    public override void SkillTrigger()
    {
        StartCoroutine(SkillTime());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SkillTime()
    {
        Debug.Log("파이어볼");
        originalAttack = gameObject.GetComponent<Wizard>().attack;
        gameObject.GetComponent<Wizard>().attack = originalAttack*2;
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<Wizard>().attack = originalAttack;
    }
}
