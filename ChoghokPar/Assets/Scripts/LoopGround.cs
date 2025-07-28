using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopGround : MonoBehaviour
{
    [SerializeField] public float _loopSpeed = 1f;
    [SerializeField] public float _loopDistance = 10f;

    private Vector2 _initialSize;
    private SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _initialSize = new Vector2(_spriteRenderer.size.x, _spriteRenderer.size.y);
    }

    // Update is called once per frame
    void Update()
    {
        _spriteRenderer.size = new Vector2(_spriteRenderer.size.x + _loopSpeed * Time.deltaTime , _spriteRenderer.size.y);

        if (_spriteRenderer.size.x > _loopDistance)
        {
            _spriteRenderer.size = _initialSize;
            //Console.WriteLine("hi");
        }
    }
}
