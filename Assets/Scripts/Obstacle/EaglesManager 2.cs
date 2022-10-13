using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class EaglesManager: MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject EagleObj;
    public static EagleFactory Ins;

    
    private const int timeInterval = 5;
    private float createTime = 0f;
    
    void Start()
    {
        CreateEagle();
    }



    // Update is called once per frame
    void Update()
    {
        if ((Time.time - createTime > timeInterval) && !EagleFactory.Ins.CheckIsFull())
        {
            CreateEagle();
        }
        

    }

    private void CreateEagle()
    {
        var obj = EagleFactory.Ins.CreateEagleFromPool();
        if (obj == null)
        {
            obj = GameObject.Instantiate(EagleObj);
            obj.transform.SetParent(transform);
        }
        obj.SetActive(true);
        createTime = Time.time;
    }
}
