using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CraftGun : MonoBehaviour
{
    public GameObject shotPrefab;
    public Transform shotSpawn;
    public float shotForce;
    public float shotSpeed;

    Craft _craft;
    Animator _anim;
    float _lastShot = 0f;


    private void Awake()
    {
        _craft = GetComponentInParent<Craft>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            if (Time.time > _lastShot + shotSpeed)
                Shoot();
        }
    }

    public void Shoot()
    {
        _anim.Play("gunShoot");

        GameObject shot = Instantiate(shotPrefab, shotSpawn.position, shotSpawn.transform.rotation);

        Rigidbody rb = shot.GetComponent<Rigidbody>();
        rb.velocity = Vector3.Project(_craft.Velocity, transform.forward);
        rb.AddForce(transform.forward * shotForce);

        _lastShot = Time.time;
    }
}
