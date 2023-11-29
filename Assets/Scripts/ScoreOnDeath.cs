using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnDeath : MonoBehaviour
{
    public int amount;

    void Awake(){
        var life = GetComponent<Life>();
        life.onDeath.AddListener(GivePoints);
    }

    private void GivePoints()
    {
        ScoreManager.instance.amount += amount;
    }
}
