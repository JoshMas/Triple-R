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
    private float scrollMultiplier;
    [SerializeField]
    private float scrollMax;
    [SerializeField]
    private float litterInitial;
    [SerializeField]
    private float litterMultiplier;
    [SerializeField]
    private float litterMax;
    [SerializeField]
    private GameObject rubbishSectionPrefab;

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
        sectionLength = rubbishSectionPrefab.GetComponent<RubbishSection>().Size.y;
    }

    // Start is called before the first frame update
    void Start()
    {
        AddRubbishSection(transform.position);
        AddRubbishSection(transform.position - Vector3.back * sectionLength);
        AddRubbishSection(transform.position - 2 * sectionLength * Vector3.back);
    }

    // Update is called once per frame
    void Update()
    {
        if(scrollSpeed < scrollMax)
            scrollSpeed += Time.deltaTime * scrollMultiplier;

        gameTimer += Time.deltaTime;
        levelSectionTimer += Time.deltaTime;
        if(levelSectionTimer >= sectionLength / scrollSpeed)
        {
            levelSectionTimer = 0;
            AddRubbishSection(transform.position - 2 * sectionLength * Vector3.back);
            RemoveRubbishSection();
        }
    }

    private void AddRubbishSection(Vector3 _position)
    {
        GameObject newSection = Instantiate(rubbishSectionPrefab, _position, Quaternion.identity);
        level.Add(newSection);
    }

    private void RemoveRubbishSection()
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
