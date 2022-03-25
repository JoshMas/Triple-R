using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Vector3 shootingVelocity;

    [SerializeField] private RubbishBag activeBag;
    [SerializeField] private RubbishBag inactiveBag;

    private void Update()
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

    public void AddRubbish(GameObject _rubbish)
    {
        activeBag.AddRubbish(_rubbish);
    }

    private void ShootRubbish()
    {
        activeBag.ShootRubbish(shootingVelocity);
    }

    public void SwapBags()
    {
        RubbishBag temp = activeBag;
        activeBag = inactiveBag;
        inactiveBag = temp;
    }
}
