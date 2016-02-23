using UnityEngine;
using System.Collections;
using System;

public enum ObjectType
{
    collectable,
    DestructableBarrier,
    FixedBarrier,
}

public class SEM_InteractableObject : MonoBehaviour
{

    public ObjectType ItemType;

    Rigidbody RB;

    // Use this for initialization
    void Start()
    {

        Setup();

    }

    private void Setup()
    {
        switch (ItemType)
        {

            case ObjectType.collectable:

                return;
            case ObjectType.DestructableBarrier:
                AddRB(0.1f);
                return;
            case ObjectType.FixedBarrier:
                AddRB(1);
                RB.constraints = RigidbodyConstraints.FreezeAll;
                return;

        }
    }

    private void AddRB(float Mass)
    {
        gameObject.AddComponent<Rigidbody>();
        RB = GetComponent<Rigidbody>();
        RB.mass = Mass;
    }

    public void OnCollisionEnter(Collision collision)
    {

        switch (ItemType)
        {

            case ObjectType.collectable:
                Destroy(gameObject);
                return;
                //todo: damage application when/if helath system implemented

        }



    }
}
