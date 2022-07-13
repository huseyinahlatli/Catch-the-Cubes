using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Transform mainCubeTransform;    
    [SerializeField] private float moveSpeed;
    private GameObject cubePrefabs;
    public List<GameObject> prefabList = new List<GameObject>();
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject restartButton;

    #region Singleton class: GameManager
    
    public static GameManager instance;

    private void Awake()
    {
        Time.timeScale = 1f;

        if (instance == null)
            instance = this;
    }

    #endregion 

    private void Start()
    {
        StartCoroutine(CreateCube());
    }

    private void Update()
    {
        scoreText.text = (prefabList.Count).ToString();
        if(Time.timeScale == 0f)
        {        
            restartButton.SetActive(true);  
            if(Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene(sceneBuildIndex: 0);
        }
    }

    IEnumerator CreateCube()
    {
        while (true)
        {
            cubePrefabs = Instantiate(
                cubePrefab,
                new Vector3(0, mainCubeTransform.transform.position.y + prefabList.Count + 1.3f, -10),
                Quaternion.identity
            );
            
            prefabList.Add(cubePrefabs);
            yield return new WaitForSeconds(4f);
        }
    }
}
