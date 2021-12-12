using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveStageBtn : Btn
{
    public override void BtnClicked()
    {
        Debug.Log("sdf");
        btnClickedSource.Play();
        StartCoroutine(LoadDelay());
    }

    IEnumerator LoadDelay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("StageScene");
    }
}
