using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleReturn : MonoBehaviour
{
    private void OnParticleSystemStopped() // 파티클의 재생이 끝나면 실행되는 함수
    {
        var particle = GetComponent<ParticleSystem>();
        EffectManger.GetInstance().RetrunEffect(particle);
    }
}
