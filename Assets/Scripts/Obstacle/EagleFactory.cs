using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleFactory : MonoBehaviour
{
    private Queue<GameObject> eaglePool = new Queue<GameObject>();
    private static EagleFactory _ins;
    
    private const int maxNum = 5;
    private int createNum;
    public static EagleFactory Ins
    {
        get
        {
            if(_ins == null)
            {
                _ins = new EagleFactory();
            }
            return _ins;
        }
    }


    public GameObject CreateEagleFromPool()
    {
        createNum += 1;
       if( eaglePool.Count > 0)
        {
            var obj = eaglePool.Dequeue();
            return obj;
        }
       
        return null;
    }

    public void BackToPool(GameObject obj)
    {
        obj.SetActive(false);
        eaglePool.Enqueue(obj);
        createNum -= 1;
    }

    // Update is called once per frame

    public bool CheckIsFull()
    {
        return createNum >= maxNum;
    }
}
