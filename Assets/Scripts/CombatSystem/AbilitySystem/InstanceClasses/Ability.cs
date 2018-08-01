using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ability
{
    public Character User { get; set; }
    public Character Target { get; set; }
    public ActionTemplate Template { get; set; }

    public float Speed { get; set; }
}
