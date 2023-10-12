using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask _damageLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Damage"))
        {
            var spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform;

            PlayerMovement.Instance.ResetMovement();
            PlayerMovement.Instance.rb.transform.position = spawnPoint.position;

            var orbs = GameObject.FindGameObjectsWithTag("Orb");
            foreach (GameObject orb in orbs)
            {
                OrbHandler script = orb.GetComponent<OrbHandler>();
                if (script != null)
                    script.Enable();
            }
        }
        else if (collision.CompareTag("Orb"))
        {
            PlayerMovement.Instance.currentGravityChanges--;
        }
    }

}
