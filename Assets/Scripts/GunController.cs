using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public float damage;
    public float speed;
    public float cooldownDuration;
    float currentCooldown;
    public int pierce;

    // Start is called before the first frame update
    void Start()
    {
        currentCooldown = cooldownDuration;
    }

    // Update is called once per frame
    void Update()
    {
        currentCooldown -= Time.deltaTime;
        if(currentCooldown < 0f ) //eventually change this with keypress perhaps.
        {
            Attack();
        }
    }

    void Attack()
    {
        currentCooldown = cooldownDuration;
    }
}
