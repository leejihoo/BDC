using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitBtn : Btn
{
    public override void BtnClicked()
    {
        btnClickedSource.Play();
        StartCoroutine(LoadDelay());
    }

    IEnumerator LoadDelay()
    {
        yield return new WaitForSeconds(1f);
        Application.Quit();                            
    }
}
