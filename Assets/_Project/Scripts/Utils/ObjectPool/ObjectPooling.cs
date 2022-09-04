using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public interface IPool<T>
{
    T Pull();
    void Push(T t);
}

public interface IPoolable<T>
{
    void Initialize(Action<T> returnAction);
    void ReturnToPool();
}

public class ObjectPooling<T> : IPool<T> where T : MonoBehaviour, IPoolable<T>
{
    private Action<T> _pullAction;
    private Action<T> _pushAction;

    private Stack<T> _pooledObjects = new Stack<T>();
    private GameObject _prefab;
    public int PooledCount => _pooledObjects.Count;

    public ObjectPooling(GameObject pooledObject, int numToSpawn = 0, Transform parent = null) // For spawning at start..
    {
        _prefab = pooledObject;
        Spawn(numToSpawn, parent);
    }

    public ObjectPooling(GameObject pooledObject, Action<T> pullAction, Action<T> pushAction, int numToSpawn = 0)
    {
        _prefab = pooledObject;
        _pullAction = pullAction;
        _pushAction = pushAction;
        Spawn(numToSpawn);
    }

    private void Spawn(int numToSpawn, Transform parent = null)
    {
        T t;

        for (int i = 0; i < numToSpawn; i++)
        {
            t = Object.Instantiate(_prefab).GetComponent<T>();
            _pooledObjects.Push(t);
            t.gameObject.SetActive(false);
            t.transform.SetParent(parent);
        }
    }

    #region Pull Methods

    public T Pull()
    {
        T t;
        if (PooledCount > 0)
        {
            t = _pooledObjects.Pop();
        }
        else
        {
            t = Object.Instantiate(_prefab).GetComponent<T>();
        }

        t.gameObject.SetActive(true);
        t.Initialize(Push);
        _pullAction?.Invoke(t);
        return t;
    }

    public T Pull(Vector3 position)
    {
        T t = Pull();
        t.transform.position = position;
        return t;
    }

    public T Pull(Vector3 position, Quaternion rotation)
    {
        T t = Pull();
        var transform = t.transform;
        transform.position = position;
        transform.rotation = rotation;
        return t;
    }

    public GameObject PullGameObject() => Pull().gameObject;

    public GameObject PullGameObject(Vector3 position)
    {
        GameObject go = Pull().gameObject;
        go.transform.position = position;
        return go;
    }

    public GameObject PullGameObject(Vector3 position, Quaternion rotation)
    {
        GameObject go = Pull().gameObject;
        go.transform.position = position;
        go.transform.rotation = rotation;
        return go;
    }

    #endregion

    public void Push(T t)
    {
        _pooledObjects.Push(t);
        _pushAction?.Invoke(t);
        t.gameObject.SetActive(false);
    }
}