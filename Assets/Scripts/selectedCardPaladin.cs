using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectedCardPaladin : selectedCard
{
    public override void SelectedSkill()
    {
        GameManager.Instance.createdAllies[0].GetComponent<Paladin>().skills.Add(new PaladinSkill());
        Destroy(gameObject);
        GameObject.Find("parentForMoveStage").transform.Find("MoveStage").gameObject.SetActive(true);
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
