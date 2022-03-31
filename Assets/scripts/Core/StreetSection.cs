using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetSection : MonoBehaviour
{
    [SerializeField]
    private Transform spawnLocation;

    private void Update()
    {
        transform.Translate(GameManager.Instance.ScrollSpeed * Time.deltaTime * Vector3.back);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Level Collider"))
            Instantiate(GameManager.Instance.GetRandomRoad(), spawnLocation.position, Quaternion.identity);
        else
            Destroy(gameObject);
    }
}
