using System;
using UnityEngine;

public abstract class ActionEffector : ScriptableObject
{
    public abstract void Effect(ActionInstance action);
}

//public abstract class ActionEffector<T> : ActionEffector
//{
//    public T Action;
//}


