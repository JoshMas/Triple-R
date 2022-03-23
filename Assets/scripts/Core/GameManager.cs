using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance;
    private void Singleton()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    [SerializeField]
    private float scrollSpeed;
    [SerializeField]
    private float litterInitial;
    [SerializeField]
    private float litterMultiplier;
    [SerializeField]
    private float litterMax;
    [SerializeField]
    private GameObject levelSectionPrefab;

    #region Prefabs
    [Space]
    [SerializeField]
    private GameObject[] litterPrefabs;
    [SerializeField]
    private GameObject[] obstaclePrefabs;
    [SerializeField]
    private GameObject[] housePrefabs;
    [SerializeField]
    private GameObject[] roadPrefabs;
    #endregion

    public float ScrollSpeed { get { return scrollSpeed; } }
    public float LitterNumber
    {
        get
        {
            float num = litterInitial + litterMultiplier * gameTimer;
            return num > litterMax ? litterMax : num;
        }
    }
    private float gameTimer = 0;
    private float levelSectionTimer = 0;
    private List<GameObject> level;

    private void Awake()
    {
        Singleton();
        level = new List<GameObject>();
    }

    // Start is called before the first frame update
    void Start()
    {
        AddLevelSection(transform.position);
        AddLevelSection(transform.position - Vector3.back * 10);
        AddLevelSection(transform.position - Vector3.back * 20);
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer += Time.deltaTime;
        levelSectionTimer += Time.deltaTime;
        if(levelSectionTimer >= 10 / scrollSpeed)
        {
            levelSectionTimer = 0;
            AddLevelSection(transform.position - Vector3.back * 20);
            RemoveLevelSection();
        }
    }

    private void AddLevelSection(Vector2 _position)
    {
        GameObject newSection = Instantiate(levelSectionPrefab, _position, Quaternion.identity);
        level.Add(newSection);
    }

    private void RemoveLevelSection()
    {
        GameObject oldSection = level[0];
        level.Remove(oldSection);
        Destroy(oldSection);
    }

    #region GetPrefab Methods
    public GameObject GetRandomLitter()
    {
        return litterPrefabs[Random.Range(0, litterPrefabs.Length)];
    }

    public GameObject GetRandomHouse()
    {
        return housePrefabs[Random.Range(0, housePrefabs.Length)];
    }

    public GameObject GetRandomObstacle()
    {
        return obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
    }

    public GameObject GetRandomRoad()
    {
        return roadPrefabs[Random.Range(0, roadPrefabs.Length)];
    }
    #endregion
}
