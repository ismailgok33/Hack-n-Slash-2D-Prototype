using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffect : ScriptableObject
{
    [TextArea]
    public string effectDescription;

    public virtual void ExecuteEffect(Transform enemyPosition)
    {
        Debug.Log("Effect executed!");
    }
}
