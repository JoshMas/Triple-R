using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSection : MonoBehaviour
{
    [SerializeField]
    private Vector2 size;
    public Vector2 Size => size;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < GameManager.Instance.LitterNumber; ++i)
        {
            Instantiate(GameManager.Instance.GetRandomLitter(), GetRandomPosition(), Quaternion.identity, transform);
        }
        Instantiate(GameManager.Instance.GetRandomHouse(), transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(GameManager.Instance.ScrollSpeed * Time.deltaTime * Vector3.back);
    }

    private Vector3 GetRandomPosition()
    {
        float xVal = size.x * .5f;
        float yVal = size.y * .5f;
        return new Vector3(Random.Range(transform.position.x - xVal, transform.position.x + xVal),
            transform.position.y,
            Random.Range(transform.position.z - yVal, transform.position.z + yVal));
    }
}
