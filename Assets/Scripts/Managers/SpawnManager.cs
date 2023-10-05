using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private Transform _spawnPoint;

    private void Awake()
    {
        SceneManager.sceneLoaded += SpawnPlayer;
    }

    private void SpawnPlayer(Scene arg0, LoadSceneMode arg1)
    {
        _spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
        var clone = Instantiate(_player, _spawnPoint.position, Quaternion.identity);
    }
}
