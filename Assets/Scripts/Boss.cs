using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public Boss()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 스태미나가 다 채워지면 공격
        StartCoroutine(StaminaRecovery());
        StateCheck();
    }
}
