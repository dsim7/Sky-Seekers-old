using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : ScriptableObject where T : Component
{
    [SerializeField]
    private T _prefab;
    private T[] _pool = new T[5];
    private int _index = 0;

    public T GetNext()
    {
        if (_index >= _pool.Length)
        {
            _index = 0;
        }
        if (_pool[_index] == null)
        {
            _pool[_index] = Instantiate(_prefab);
        }
        return _pool[_index++];
    }
}
