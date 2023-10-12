using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private void Awake()
    {
        SceneManager.sceneLoaded += SpawnPlayer;
    }

    private void SpawnPlayer(Scene arg0, LoadSceneMode arg1)
    {
        var spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");

        if(spawnPoint != null)
        {
            var clone = Instantiate(_player, spawnPoint.transform.position, Quaternion.identity);
        }
    }
}
