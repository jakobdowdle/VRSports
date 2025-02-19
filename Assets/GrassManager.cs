using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassManager : MonoBehaviour
{
    [SerializeField] private GameObject _grassPrefab;
    [SerializeField] private int _bladesToSpawn;
    [SerializeField] private float _radiusToSpawn;
    [SerializeField] private float _minSize, _maxSize;
    // Start is called before the first frame update
    void Start()
    {
        GameObject grass;
        for (int i = 0; i < _bladesToSpawn; i++)
        {
            grass = Instantiate(_grassPrefab, transform);
            grass.transform.position = new Vector3(Random.Range(-_radiusToSpawn, _radiusToSpawn), 0, Random.Range(-_radiusToSpawn, _radiusToSpawn));
            grass.transform.localScale = new Vector3(Random.Range(_minSize, _maxSize), Random.Range(_minSize, _maxSize), 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
