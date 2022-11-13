using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float m_duration, float m_magnitude)
    {
        Vector3 m_originalPos = transform.localPosition;
        float m_timePassed = 0.0f;

        while(m_timePassed < m_duration){
            float m_x = Random.Range(-1f,1f) * m_magnitude;
            float m_y = Random.Range(-1f,1f) * m_magnitude;

            transform.localPosition = new Vector3(m_x, m_y, m_originalPos.z);

            m_timePassed += Time.deltaTime;
            yield return null; //wait for next frame to continue
        }

        transform.localPosition = m_originalPos;
        yield break; //stop couritine 
    }
}
