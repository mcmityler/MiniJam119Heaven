using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRenderOrderScript : MonoBehaviour
{
    [SerializeField] float _updateSpritePosTime = 1f;
    float _counter = 0f;
    void FixedUpdate()
    {
        _counter += Time.deltaTime;
        if (_counter >= _updateSpritePosTime) //make it more effecient / less costly
        {
            _counter = 0f;
            SpriteRenderer[] _spriteRenderers = FindObjectsOfType<SpriteRenderer>();

            foreach (SpriteRenderer m_render in _spriteRenderers)
            {
                if (m_render.gameObject.tag != "Background")
                {
                    m_render.sortingOrder = (int)(m_render.transform.position.y * -100);
                }
            }
        }

    }
}
