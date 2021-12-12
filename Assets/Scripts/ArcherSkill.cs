using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherSkill : Skill
{
    int originalStamina;
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
        Debug.Log("¼Ó»ç");
        originalStamina = gameObject.GetComponent<Archer>().maxStamina;
        gameObject.GetComponent<Archer>().maxStamina = 1;
        yield return new WaitForSeconds(3f);
        gameObject.GetComponent<Archer>().maxStamina = originalStamina;
    }


}
