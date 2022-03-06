using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandProjectile : MonoBehaviour
{
    public GameObject attackingParticle;
    public float attackSpeed;

    public GameObject projectileParent;
    public GameObject cameraObjectX;
    public GameObject playerObjectY;

    private void Start()
    {
        projectileParent = GameObject.Find("ProjectileParent");
        cameraObjectX = GameObject.Find("Player Camera");
        playerObjectY = GameObject.Find("Player");
    }

    private void Update()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Quaternion rotation = transform.rotation;
                rotation.x = cameraObjectX.transform.rotation.x;
                rotation.y = playerObjectY.transform.rotation.y;
                var newPart = Instantiate(attackingParticle, transform.position, transform.rotation, projectileParent.transform);
                newPart.GetComponent<ParticleSystem>().Play();
                newPart.GetComponent<Rigidbody>().AddForce(attackSpeed * Vector3.forward, ForceMode.Impulse);
            }
        }
    }
}
