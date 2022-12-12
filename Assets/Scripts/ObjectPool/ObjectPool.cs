using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance = null;

    private void Awake()
    {
        Instance = this;

        Initialize(20);
    }

    [SerializeField]
    private GameObject poolingObjectPrefab;

    private Queue<HitEffect> poolingObjectQueue = new Queue<HitEffect>();

    private HitEffect CreateNewObject()
    {
        var newObj = Instantiate(poolingObjectPrefab, transform).GetComponent<HitEffect>();
        newObj.gameObject.SetActive(false);
        return newObj;
    }

    private void Initialize(int count)
    {
        for (int i = 0; i < count; i++)
        {
            poolingObjectQueue.Enqueue(CreateNewObject());
        }
    }

    public static HitEffect GetObject()
    {
        if (true)
        {
            var obj = Instance.poolingObjectQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = Instance.CreateNewObject();
            newObj.transform.SetParent(null);
            newObj.gameObject.SetActive(true);
            return newObj;
        }
    }

    public static void ReturnObject(HitEffect effect)
    {
        effect.gameObject.SetActive(false);
        effect.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue.Enqueue(effect);
    }

}
