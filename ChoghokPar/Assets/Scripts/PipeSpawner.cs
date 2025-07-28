using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float _maxTime = 1.5f;
    [SerializeField] private float _heightRange = 0.45f;
    [SerializeField] private GameObject _pipePrefab;

    private float _timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer >_maxTime)
        {
            SpawnPipe();
            _timer = 0;
        }
        _timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0 , Random.Range(-_heightRange, _heightRange));
        GameObject pipe = Instantiate(_pipePrefab, spawnPosition, Quaternion.identity);
        //pipe.transform.position += Vector3.up * Random.Range(-_heightRange, _heightRange);
        Destroy(pipe, 10);
    }
}
