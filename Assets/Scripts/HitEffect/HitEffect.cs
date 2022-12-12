using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public void ShootEffect()
    {
        Invoke("DestroyEffect", 1f);
    }
    private void DestroyEffect()
    {
        ObjectPool.ReturnObject(this);
    }
}
