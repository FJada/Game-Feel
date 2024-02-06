using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{

    GunController gc;

    Vector3 direction;
    public float destroyAfterSeconds;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    // Update is called once per frame
    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;
    }

    void Update()
    {
        transform.position += direction * gc.speed * Time.deltaTime;
    }
}
