using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManger : MonoBehaviour
{
    #region Singletone
    private static EffectManger Instance = null;
    public static EffectManger GetInstance()
    {
        if (Instance == null)
        {
            GameObject go = new GameObject("@EffectManger");
            Instance = go.AddComponent<EffectManger>();

            DontDestroyOnLoad(go);
        }
        return Instance;
    }
    #endregion

    Stack<ParticleSystem> effectPool = new Stack<ParticleSystem>();

    /// <summary>
    /// 이펙트 풀링을 초기화하는 함수입니다.
    /// </summary>
    /// <param name="size">초기화하는 이펙트 사이즈</param>
    public void InitEffectPool(int size)
    {
        for (int i = 0; i < size; i++)
        {
            var effect = ObjectManager.GetInstance().CreateHitEffect();
            effect.gameObject.SetActive(false);
            effectPool.Push(effect);
        }

    }

    public void ReleasePool()
    {
        effectPool.Clear(); // 스택을 클리어 해줘도 힙영역에있는 오브젝트는 파괴되지 않는다.
    }

    public void UseEffect()
    {
        if (effectPool.Count > 0)
        {
            var effect = effectPool.Pop(); // effectPool은 지금 ParticleSystem의 형식이라
            effect.gameObject.SetActive(true); // effect에서 ParticleSyste의 컴포넌트를 사용할수 있다.
            effect.Play();

            float randX = Random.Range(-1.7f, 1.7f);
            float randY = Random.Range(-1.7f, 1.7f);

            effect.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            effect.transform.localPosition = new Vector3(0 + randX, 0.7f + randY, -0.5f);
        }
        else // 사용가능한 파티클이 없다면 새로 생성해주고 플레이 해주겠다.
        {
            var effect = ObjectManager.GetInstance().CreateHitEffect();
            effect.Play();

            float randX = Random.Range(-1.7f, 1.7f);
            float randY = Random.Range(-1.7f, 1.7f);

            effect.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            effect.transform.localPosition = new Vector3(0 + randX, 0.7f + randY, -0.5f);

        }
        
    }

    public void RetrunEffect(ParticleSystem particle)
    {
        particle.gameObject.SetActive(false);
        effectPool.Push(particle);
    }


}
