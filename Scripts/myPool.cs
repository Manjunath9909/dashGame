using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public static class myPool
{
    public static Dictionary<string, Queue<Component>> poolDictionary = new Dictionary<string, Queue<Component>>();

    public static void setUpMyPool<T>(T prefabItem, int poolSize, string dictEntry) where T : Component
    {
        poolDictionary.Add(dictEntry, new Queue<Component>());

        for (int i = 0; i < poolSize; i++)
        {
            T pooledInstance = UnityEngine.Object.Instantiate(prefabItem);
            pooledInstance.gameObject.SetActive(false);
            poolDictionary[dictEntry].Enqueue((T)pooledInstance);
        }
    }

    public static void enqueueObject<T>(T item, String name) where T : Component
    {
        //if the item is already active doing nothing
        if (!item.gameObject.activeSelf) { return; }
        item.transform.position = Vector2.zero;
        poolDictionary[name].Enqueue(item);
        item.gameObject.SetActive(false);
    }

    public static T dequeueObject<T>(String key) where T : Component
    {
        return (T)poolDictionary[key].Dequeue();
    }
}
