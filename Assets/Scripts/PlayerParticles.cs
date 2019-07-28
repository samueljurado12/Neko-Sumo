using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticles : MonoBehaviour {
    public GameObject particlesWalk;
    public GameObject particlesMelee;
    public GameObject particlesSpit;

    public void WalkParticles() {
        Instantiate(particlesWalk, new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z), Quaternion.identity);
    }

    public void MeleeParticles() {
        Instantiate(particlesMelee, new Vector3(transform.position.x + transform.parent.localScale.x * 1.5f, transform.position.y + 0.2f, transform.position.z), Quaternion.identity);
    }

    public void SpitParticles() {
        Instantiate(particlesSpit, new Vector3(transform.position.x + transform.parent.localScale.x, transform.position.y + 0.7f, transform.position.z), Quaternion.identity);
    }
}
