using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Slider bar;
    // Start is called before the first frame update
     void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var character = transform.parent.parent.GetComponent<Charater>();
        bar.value = (float)character.currentHp / character.maxHp;
    }
}
