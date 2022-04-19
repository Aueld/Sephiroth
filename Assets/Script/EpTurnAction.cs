using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EpTurnAction : MonoBehaviour
{
    private GameObject hero;
    private GameObject enemy;

    [SerializeField]
    private GameObject meleePrefab;

    [SerializeField]
    private GameObject rangePrefab;

    [SerializeField]
    private Sprite faceIcon;

    private GameObject currentAttack;

    private void Awake()
    {
        hero = GameObject.FindGameObjectWithTag("Hero");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }
       
    public void SelectAttack(string btn)
    {
        GameObject victim = hero;

        if (this.tag == "Hero")
            victim = enemy;

        if (btn.CompareTo("melee") == 0)
            meleePrefab.GetComponent<EpAttackScript>().Attack(victim);
        else if (btn.CompareTo("range") == 0)
            rangePrefab.GetComponent<EpAttackScript>().Attack(victim);
        else
            Debug.Log("RR");
    }
}
