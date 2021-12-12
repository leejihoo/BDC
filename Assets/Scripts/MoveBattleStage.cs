using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveBattleStage : Btn
{
    public override void BtnClicked()
    {
        GameManager.Instance.stageInfo = gameObject.name;
        btnClickedSource.Play();
        StartCoroutine(LoadDelay());
    }

    IEnumerator LoadDelay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("BattleScene");
    }
}
