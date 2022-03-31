using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Vector3 shootingVelocity;

    [SerializeField] private RubbishBag activeBag;
    [SerializeField] private RubbishBag inactiveBag;

    [SerializeField] private bool manualSort;

    [SerializeField] private TextMeshProUGUI red;
    [SerializeField] private TextMeshProUGUI yellow;

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
        if (manualSort)
        {
            activeBag.AddRubbish(_rubbish);
        }
        else
        {
            if (_rubbish.GetComponent<Rubbish>().Recyclable)
            {
                inactiveBag.AddRubbish(_rubbish);
            }
            else
            {
                activeBag.AddRubbish(_rubbish);
            }
        }

        UpdateText();
    }

    private void ShootRubbish()
    {
        activeBag.ShootRubbish(shootingVelocity);
        UpdateText();
    }

    private void ShootRubbish(bool _recyclable)
    {
        if (_recyclable)
        {
            inactiveBag.ShootRubbish(shootingVelocity);
        }
        else
        {
            activeBag.ShootRubbish(shootingVelocity);
        }
        UpdateText();
    }

    private void UpdateText()
    {
        red.text = "" + activeBag.GetCapacityFraction();
        yellow.text = "" + inactiveBag.GetCapacityFraction();
    }

    public void SwapBags()
    {
        RubbishBag temp = activeBag;
        activeBag = inactiveBag;
        inactiveBag = temp;
        UpdateText();
    }
}
