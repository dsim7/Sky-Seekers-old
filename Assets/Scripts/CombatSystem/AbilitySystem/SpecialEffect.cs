using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Combat/ActionSpecialEffect")]
public class SpecialEffect : ScriptableObject
{
    [SerializeField]
    private ParticleSystem _prefab;
    private ParticleSystem[] _pool = new ParticleSystem[5];
    private int _index = 0;

    public void Display(Vector3 position)
    {
        if (_index >= _pool.Length)
        {
            _index = 0;
        }

        if (_pool[_index] == null)
        {
            _pool[_index] = Instantiate(_prefab);
        }
        ParticleSystem sfx = _pool[_index];
        sfx.transform.position = position;
        sfx.Play();

        _index++;
    }
}
