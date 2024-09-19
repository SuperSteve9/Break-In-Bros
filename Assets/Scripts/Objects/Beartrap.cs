using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beartrap : MonoBehaviour
{
    // Public:
    [Header("General Properties")]
    public int damageDealt;

    // Private:
    private Vector3 trapPosition;
    private bool onCooldown = false;
    private GameObject player = null;

    IEnumerator Cooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(5);
        onCooldown = false;
    }

    IEnumerator TrapClose()
    {
        // Player consequences
        player.gameObject.GetComponent<PlayerMovement>().TakeDamage(damageDealt);
        player.gameObject.GetComponent<CharacterController>().enabled = false;

        player.transform.position = new Vector3(trapPosition.x, player.transform.position.y, trapPosition.z);

        yield return new WaitForSeconds(5);

        player.gameObject.GetComponent<CharacterController>().enabled = true;
        player = null;

        StartCoroutine("Cooldown");
    }

    // Start is called before the first frame update
    void Start()
    {
        trapPosition = transform.parent.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !onCooldown)
        {
            player = other.gameObject;
            StartCoroutine("TrapClose");
        }
    }
}
