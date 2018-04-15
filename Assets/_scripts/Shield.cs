using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float forceDampening = 0.75f;

    public bool Active { get { return _active; } }

    MeshRenderer _mr;
    bool _active = true;


    private void Awake()
    {
        _mr = GetComponent<MeshRenderer>();
    }

    /// <summary>
    /// adds 'damage' to this shield and dampens force
    /// </summary>
    /// <returns>the original force dampened by this shield's forceDampening</returns>
    public float AbsorbForce(float force, Vector3 point)
    {
        // TODO: check craft energy(?) and deactivate if neccessary
        // TODO: show shield at point of impact
        StopCoroutine("Flash");
        StartCoroutine("Flash");
        return force *= forceDampening;
    }

    IEnumerator Flash()
    {
        _mr.enabled = true;
        yield return new WaitForSeconds(0.5f);
        _mr.enabled = false;
    }
}
