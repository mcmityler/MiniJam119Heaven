using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRenderOrderScript : MonoBehaviour
{
    void Update(){
        SpriteRenderer[] _spriteRenderers = FindObjectsOfType<SpriteRenderer>();

        foreach (SpriteRenderer m_render in _spriteRenderers)
        {
            m_render.sortingOrder = (int)(m_render.transform.position.y*-100);
        }
    }
}
