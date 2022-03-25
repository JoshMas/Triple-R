using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbishBag : MonoBehaviour
{
    public bool Recyclable;
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
        Debug.Log(rubbish.Count);
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
}
