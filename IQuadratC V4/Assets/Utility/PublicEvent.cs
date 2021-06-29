using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PublicEvent", menuName = "Utility/PublicEvent")]
public class PublicEvent : ScriptableObject
{
    private Action[] funcs = new Action[8];
    private int maxId = 0;
    private List<int> freeIds = new List<int>();
    
    public void Raise()
    {
        foreach (Action func in funcs)
        {
            func?.Invoke();
        }
    }

    public int Register(Action func)
    {
        int id;
        if (freeIds.Count == 0)
        {
            id = maxId;
            maxId++;
        }
        else
        {
            id = freeIds[0];
            freeIds.RemoveAt(0);
        }
        
        if (funcs.Length >= id)
        {
            raiseArray();
        }
        
        funcs[id] = func;
        return id;
    }

    public void Unregister(int id)
    {
        freeIds.Add(id);
        funcs[id] = null;
    }

    private void raiseArray()
    {
        int length = funcs.Length;
        Action[] newFunc = new Action[length * 2];
        
        for (int i = 0; i < length; i++)
        {
            newFunc[i] = funcs[i];
        }
        
        funcs = newFunc;
    }
}
