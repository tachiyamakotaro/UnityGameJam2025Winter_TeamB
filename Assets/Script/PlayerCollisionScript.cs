using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionScript : MonoBehaviour
{
    private PlayerStateScript playerState;

    // Start is called before the first frame update
    void Start()
    {
        playerState = GetComponent<PlayerStateScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            playerState.TakeDamage(5);
        }
    }
}
