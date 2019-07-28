using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterParticles : MonoBehaviour
{
    [SerializeField] GameObject waterParticle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.gameObject.GetComponent<CharacterController>() != null)
        Destroy(Instantiate(waterParticle, collision.transform.position, Quaternion.identity), 0.5f);
    }
}
