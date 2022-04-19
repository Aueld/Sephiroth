using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EpButton : MonoBehaviour
{
    [SerializeField]
    private bool physical;

    private GameObject hero;

    private void Start()
    {
        string temp = gameObject.name;
        gameObject.GetComponent<Button>().onClick.AddListener(() => AttachCallback(temp));
        hero = GameObject.FindGameObjectWithTag("Hero");
    }

    private void AttachCallback(string btn)
    {
        if(btn.CompareTo("MeleeBtn") == 0)
            hero.GetComponent<EpTurnAction>().SelectAttack("melee");
        
        else if (btn.CompareTo("RangeBtn") == 0)
            hero.GetComponent<EpTurnAction>().SelectAttack("range");
        
        else
            hero.GetComponent<EpTurnAction>().SelectAttack("RR");
    }
}
