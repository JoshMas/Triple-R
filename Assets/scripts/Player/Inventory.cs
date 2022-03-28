using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Vector3 shootingVelocity;

    [SerializeField] private RubbishBag activeBag;
    [SerializeField] private RubbishBag inactiveBag;

    [SerializeField] private bool manualSort;

    private void Update()
    {
        if (manualSort)
        {
            if (Input.GetMouseButtonDown(1))
            {
                SwapBags();
            }
            if (Input.GetMouseButtonDown(0))
            {
                ShootRubbish();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                ShootRubbish(false);
            }
            if (Input.GetMouseButtonDown(1))
            {
                ShootRubbish(true);
            }
        }
    }

    public void AddRubbish(GameObject _rubbish)
    {
        activeBag.AddRubbish(_rubbish);
    }

    private void ShootRubbish()
    {
        activeBag.ShootRubbish(shootingVelocity);
    }

    private void ShootRubbish(bool _recyclable)
    {
        activeBag.ShootRubbish(_recyclable, shootingVelocity);
    }

    public void SwapBags()
    {
        RubbishBag temp = activeBag;
        activeBag = inactiveBag;
        inactiveBag = temp;
    }
}
