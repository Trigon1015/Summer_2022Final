using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNumber : MonoBehaviour
{
    public Sprite[] nums;
    public Sprite[] nums_crit;
    public Sprite[] nums_large;

    public Rigidbody2D _rb;
    public SpriteRenderer _renderer;
    public bool crit = false;

    public int damage = 0;

    private void Start()
    {
        _rb.velocity = Vector2.up;
        StartCoroutine(Fade());
        if (crit == false)
        {
            _renderer.sprite = nums[damage];
        }
        else
        {
            _renderer.sprite = nums_crit[damage];
        }
    }

    private IEnumerator Fade()
    {
        Color c = _renderer.material.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.05f)
        {
            c.a = alpha;
            _renderer.material.color = c;
            yield return null;
        }
        Destroy(gameObject);
    }
}
