using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMover : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float disableDelay = 3f;

    private bool isMoving = false;

    public void StartMoving()
    {
        isMoving = true;
        Invoke("DisableSelf", disableDelay);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }

    void DisableSelf()
    {
        gameObject.SetActive(false);
    }
}
