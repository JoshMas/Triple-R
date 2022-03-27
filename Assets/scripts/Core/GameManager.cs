using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;

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
    private float sectionLength;
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
        sectionLength = levelSectionPrefab.GetComponent<LevelSection>().Size.y;
    }

    // Start is called before the first frame update
    void Start()
    {
        AddLevelSection(transform.position);
        AddLevelSection(transform.position - Vector3.back * sectionLength);
        AddLevelSection(transform.position - 2 * sectionLength * Vector3.back);
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer += Time.deltaTime;
        levelSectionTimer += Time.deltaTime;
        if(levelSectionTimer >= sectionLength / scrollSpeed)
        {
            levelSectionTimer = 0;
            AddLevelSection(transform.position - 2 * sectionLength * Vector3.back);
            RemoveLevelSection();
        }
    }

    private void AddLevelSection(Vector3 _position)
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

    public void AddScore(int _amount)
    {
        score += _amount;
        scoreText.text = "Score: " + score;
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
