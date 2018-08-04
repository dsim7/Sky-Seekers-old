using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionInitializer : ScriptableObject
{
    public string Animation { get; set; }
    public float Speed { get; set; }

    public virtual void InitializeData(ActionInstance action)
    {
        action.Animation = Animation;
        action.Speed = Speed;
    }
}

//public abstract class ActionInitializer<T> : ActionInitializer where T : new()
//{
//    public T Action;
//}
