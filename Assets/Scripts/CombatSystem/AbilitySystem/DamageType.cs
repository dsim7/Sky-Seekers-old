using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Combat/DamageType")]
public class DamageType : ScriptableObject
{
    [SerializeField]
    private Color _color;
    public Color Color { get { return _color; } set { _color = value; } }
}
