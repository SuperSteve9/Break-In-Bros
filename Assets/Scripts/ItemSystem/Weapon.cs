using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Weapon : Item
{
    [Header("Weapon Properties")]
    public int damage;
    public int cooldown;

    private bool onCooldown = false;

    private IEnumerator Cooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(cooldown);
        onCooldown = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseItem()
    {
        if (onCooldown)
            return;

        LayerMask player = LayerMask.GetMask("Player");

        RaycastHit hit;
        if (Physics.SphereCast(transform.position, 0.5f, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, player))
        {
            hit.collider.GetComponent<PlayerMovement>().health -= damage;
        }

        StartCoroutine("Cooldown");
    }
}
