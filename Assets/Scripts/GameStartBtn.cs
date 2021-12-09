using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartBtn : Btn
{
    public override void BtnClicked()
    {
        btnClickedSource.Play();
        StartCoroutine(LoadDelay());
    }

    IEnumerator LoadDelay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("teamCompositionScene");
    }
}
