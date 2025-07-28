using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBehaviour : MonoBehaviour
{
    [SerializeField] private float _velocity = 1.5f;
    [SerializeField] private float _rotationSpeed = 10f;

    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (_rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on " + gameObject.name);
        }
    }

    void Update()
    {
        if (IsTouchedOrClicked())
        {
            _rb.linearVelocity = Vector2.up * _velocity;
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, _rb.linearVelocity.y * _rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameManager.Instance.GameOver();
    }

    /// <summary>
    /// Detects touch on mobile or mouse click on PC using the old Input system.
    /// </summary>
    private bool IsTouchedOrClicked()
    {
        // For mobile touch
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            return true;

        // For mouse click
        if (Input.GetMouseButtonDown(0))
            return true;

        return false;
    }
}
