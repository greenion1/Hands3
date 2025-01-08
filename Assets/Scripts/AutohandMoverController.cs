using System;
using System.Collections;
using System.Collections.Generic;
using Autohand;
using UnityEngine;

public class AutohandMoverController : MonoBehaviour
{
    [System.Flags]
    public enum CustomRigidbodyConstraints
    {
        None = RigidbodyConstraints.None,
        FreezePositionX = RigidbodyConstraints.FreezePositionX,
        FreezePositionY = RigidbodyConstraints.FreezePositionY,
        FreezePositionZ = RigidbodyConstraints.FreezePositionZ,
        FreezeRotationX = RigidbodyConstraints.FreezeRotationX,
        FreezeRotationY = RigidbodyConstraints.FreezeRotationY,
        FreezeRotationZ = RigidbodyConstraints.FreezeRotationZ,
        FreezePosition = RigidbodyConstraints.FreezePosition,
        FreezeRotation = RigidbodyConstraints.FreezeRotation,
        FreezeAll = RigidbodyConstraints.FreezeAll
    }


    public CustomRigidbodyConstraints defaultConstraints;
    public Grabbable horizontalGrabbable;
    public CustomRigidbodyConstraints horizontalConstraints;
    public Grabbable verticalGrabbable;
    public CustomRigidbodyConstraints verticalConstraints;

    public Rigidbody[] rigidBodies;
    // Start is called before the first frame update
    void Start()
    {
        horizontalGrabbable.onGrab.AddListener(OnGrab);
        horizontalGrabbable.onRelease.AddListener(OnRelease);
        verticalGrabbable.onGrab.AddListener(OnGrab);
        verticalGrabbable.onRelease.AddListener(OnRelease);
    }

    private void OnRelease(Hand arg0, Grabbable arg1)
    {
        if (arg1 == horizontalGrabbable)
        {
            foreach (Rigidbody item in rigidBodies)
            {
                item.constraints = (RigidbodyConstraints)defaultConstraints;
            }

        }

        if (arg1 == verticalGrabbable)
        {
            foreach (Rigidbody item in rigidBodies)
            {
                item.constraints = (RigidbodyConstraints)defaultConstraints;
            }
        }
    }

    private void OnGrab(Hand arg0, Grabbable arg1)
    {
        if (arg1 == horizontalGrabbable)
        {
            foreach (Rigidbody item in rigidBodies)
            {
                item.constraints = (RigidbodyConstraints)horizontalConstraints;
            }
        }

        if (arg1 == verticalGrabbable)
        {
            foreach (Rigidbody item in rigidBodies)
            {
                item.constraints = (RigidbodyConstraints)verticalConstraints;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
