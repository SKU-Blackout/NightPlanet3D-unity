using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBase<T> where T:UnityEngine.Component
{
    protected Dictionary<string, T> objDict = new Dictionary<string, T>();
    protected int idx = 0;
    

    public void PushAll()
    {
        T[] obs = UnityEngine.GameObject.FindObjectsOfType<T>();
        foreach (T ob in obs)
        {
            ob.name += idx++;
            objDict.Add(ob.name, ob);
        }
    }

    public virtual T Instantiate(string path)
    {
        GameObject go = GameManager.Resource.Instantiate(path);
        go.name += idx++;

        T tmp = go.GetOrAddComponent<T>();
        objDict.Add(go.name, tmp);
        return tmp;
    }

    public T Get(string objectName)
    {
        T tmp;
        if (objDict.TryGetValue(objectName, out tmp) == false)
            return null;

        return tmp;
    }

    public virtual void Clear()
    {
        idx = 0;
        foreach (string key in objDict.Keys)
            GameManager.Resource.Destroy(objDict[key].gameObject);
        objDict.Clear();
    }

}
