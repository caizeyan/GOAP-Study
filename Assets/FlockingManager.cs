using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FlockingManager : MonoBehaviour
{
    public int fishNum = 20;
    public GameObject fishPrefab;
    public GameObject[] fishes;
    public Vector3 activeRange = new Vector3(5,5,5);

    public Bounds limitBounds;
    public static FlockingManager fm;
    
    [Header("Fish Setting")] [Range(0, 10)]
    public float minSpeed = 3;
    [Range(0,10)]
    public float maxSpeed = 5;
    // Start is called before the first frame update
    [Range(0.1f,5f)]
    public float rotationSpeed = 1f;
    public float neighborDistance = 5;
    
    public Vector3 targetGol = Vector3.zero;
    void Start()
    {
        fm = this;
        fishes = new GameObject[fishNum];
        for (int i = 0; i < fishNum; i++)
        {
            var pos = new Vector3(
                Random.Range(-activeRange.x, activeRange.x),
                Random.Range(-activeRange.y, activeRange.y),
                Random.Range(-activeRange.z, activeRange.z)
            );
            var go = Instantiate(fishPrefab, pos, Quaternion.identity);
            fishes[i] = go;
        }

        limitBounds = new Bounds(transform.position, activeRange * 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0,100) < 3)
        {
            targetGol = new Vector3(
                Random.Range(-activeRange.x, activeRange.x),
                Random.Range(-activeRange.y, activeRange.y),
                Random.Range(-activeRange.z, activeRange.z)
            );
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(targetGol,1);
        Gizmos.DrawWireCube(transform.position,activeRange*2);
    }
}
