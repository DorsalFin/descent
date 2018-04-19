using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseCheckpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Craft"))
            CourseManager.Instance.HitCheckpoint(transform.GetSiblingIndex());
    }
}
