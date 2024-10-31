using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(FlockingManager.fm.minSpeed, FlockingManager.fm.maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        //限制在bounds内
        if (!FlockingManager.fm.limitBounds.Contains(transform.position))
        {
            var dir = FlockingManager.fm.transform.position - transform.position;
            transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.LookRotation(dir), FlockingManager.fm.rotationSpeed*2 );
        }else if (Random.Range(0,100) < 40)
        {
            speed = Random.Range(FlockingManager.fm.minSpeed, FlockingManager.fm.maxSpeed);
            ApplyRule();
        }
        transform.Translate(Vector3.forward*speed*Time.deltaTime);
    }

    void ApplyRule()
    {
        GameObject[] goes = FlockingManager.fm.fishes;
        Vector3 vCenter = Vector3.zero;
        Vector3 vVoid = Vector3.zero;
        Vector3 allForward = Vector3.zero;
        float neigborSize = 0;
        foreach (var fish in goes)
        {
            var distance = Vector3.Distance(transform.position, fish.transform.position);
            if (distance < FlockingManager.fm.neighborDistance)
            {
                vCenter += fish.transform.position;
                if (fish != this && distance < 1.0f)
                {
                    vVoid += (transform.position - fish.transform.position);
                }
                neigborSize++;
                allForward += fish.transform.forward;
            }
        }
        
        //设置速度
        vCenter = vCenter/neigborSize + FlockingManager.fm.targetGol-transform.position;
        Vector3 direction = vCenter*3 + vVoid + allForward/neigborSize;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction),
                FlockingManager.fm.rotationSpeed * Time.deltaTime);
    }
}
