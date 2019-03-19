using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton

    private static GameManager _instance;

    public static GameManager Instance => _instance;

    private void Awake()
    {
        _instance = GetComponent<GameManager>();
    }

    #endregion

    [Range(0, 10f)] public float orbSpeed;
    [SerializeField] private GameObject orbPrefab;
    [SerializeField] private Transform playerTransform;

    private List<GameObject> _orbList = new List<GameObject>();
    private int _orbCount = 0;

    public void InstanceOrb()
    {
        GameObject newOrb = Instantiate(orbPrefab);
        float averageDegree = 360 / (_orbList.Count + 1);
        
        _orbList.Add(newOrb);
        for (int i = 1; i < _orbList.Count+1; i++)
        {
            _orbList[i - 1].GetComponent<OrbController>().SetOrb(playerTransform.position, 1, averageDegree * i);
        }
        _orbCount++;
    }
}
