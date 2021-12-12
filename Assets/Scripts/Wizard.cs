using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Ally
{
    public Wizard()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        var BattleEnd = GameManager.Instance.BattleEnd;
        var currentScene = GameManager.Instance.currentScene;
        if (!BattleEnd && currentScene == "BattleScene")
            StartCoroutine(StaminaRecovery());
        StateCheck();
    }


}
