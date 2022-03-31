using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Rubbish : MonoBehaviour
{
    public bool Recyclable;
    private SphereCollider sphereCollider;
    private Vector3 velocity;
    private void Awake()
    {
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
    }

    private void Update()
    {
        transform.Translate(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Inventory>().AddRubbish(gameObject);
        }
        else if (other.CompareTag("Bin"))
        {
            if (other.GetComponent<Bin>().Recyclable == Recyclable)
            {
                GameManager.Instance.AddScore(1);
                timer_countdown.Instance.AddTime(2);
            }
            else if (!Recyclable)
                timer_countdown.Instance.AddTime(-0.5f);

            Destroy(gameObject);
        }
        else
        {
            timer_countdown.Instance.AddTime(-.5f);
            Destroy(gameObject);
        }
    }



    public void Shoot(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void AddRubbish(Vector3 _start, Vector3 _end)
    {
        StartCoroutine(nameof(Jump), (_start, _end));
    }

    private IEnumerator Jump(Vector3 _start, Vector3 _end)
    {
        transform.position = _start;
        yield return null;
        transform.position = _end;
    }
}
