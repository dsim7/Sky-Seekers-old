using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Combat/ActionType")]
public class ActionType : ScriptableObject
{
    [SerializeField]
    private ActionTypeSet set;

    void OnEnable()
    {
        set.Add(this);
    }

    void OnDisable()
    {
        set.Remove(this);
    }
}
