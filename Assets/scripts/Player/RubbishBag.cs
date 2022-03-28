using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishBag : MonoBehaviour
{
    //public bool Recyclable;
    private List<GameObject> rubbish;
    [SerializeField]
    private int capacity;

    private void Awake()
    {
        rubbish = new List<GameObject>();
    }

    public void AddRubbish(GameObject _rubbish)
    {
        if(rubbish.Count < capacity)
        {
            _rubbish.transform.parent = null;
            rubbish.Add(_rubbish);
            _rubbish.SetActive(false);
        }
        else
        {

        }
        //Debug.Log(rubbish.Count);
    }

    public void ShootRubbish(Vector3 _velocity)
    {
        if(rubbish.Count == 0)
        {
            return;
        }
        GameObject shot = rubbish[0];
        shot.SetActive(true);
        shot.transform.position = transform.position;
        shot.GetComponent<Rubbish>().Shoot(_velocity);
        rubbish.Remove(shot);
    }

    public void ShootRubbish(bool _recyclable, Vector3 _velocity)
    {
        if (rubbish.Count == 0)
        {
            return;
        }
        GameObject shot = rubbish[0];
        foreach(GameObject item in rubbish)
        {
            if(item.GetComponent<Rubbish>().Recyclable == _recyclable)
            {
                shot = item;
                break;
            }
        }
        Rubbish shotScript = shot.GetComponent<Rubbish>();
        if(shotScript.Recyclable != _recyclable)
        {
            return;
        }
        shot.SetActive(true);
        shot.transform.position = transform.position;
        shotScript.Shoot(_velocity);
        rubbish.Remove(shot);
    }

    public float GetCapacityFraction()
    {
        return (float)rubbish.Count / capacity;
    }
}
