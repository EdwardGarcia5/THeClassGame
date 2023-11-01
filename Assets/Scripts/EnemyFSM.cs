using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    public enum EnemyState{GotoBase,AttackBase,ChasePlayer,AttackPlayer};
    public EnemyState currentState;

    void Update()
    {
        if(currentState == EnemyState.GotoBase)
        {
            print("Go to base");
        }
        else if (currentState == EnemyState.AttackBase)
        {
            print("Attack base");
        }
        else if (currentState == EnemyState.ChasePlayer)
        {
            print("Chase player");
        }
        else
        {
            print("Attack player");
        }
    }


}
