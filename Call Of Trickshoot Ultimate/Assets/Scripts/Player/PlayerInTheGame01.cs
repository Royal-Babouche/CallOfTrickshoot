using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerInTheGame01 : MonoBehaviour
{
    [SerializeField] private GameParametreData _gameParametreData;
    [SerializeField] private List<PlayerConfiguration> playerConfigs;
    [SerializeField] private Transform _parentCanvas;

    public static PlayerInTheGame01 Instance { get; set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("SINGLETON - Trying to create another instance of singleton!");
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            playerConfigs = new List<PlayerConfiguration>();
            _gameParametreData.Instance();
        }
    }

    public List<PlayerConfiguration> GetPlayerConfigs()
    {
        return playerConfigs;
    }

    public void HandlePlayerJoin(PlayerInput pi)
    {
        Debug.Log("Player Joined : " + pi.playerIndex);
        pi.transform.SetParent(transform);
        //pi.GetComponent<PlayerSetupConfiguration01>().InitializePlayerConfiguration(_parentCanvas, pi);
        if (!playerConfigs.Any(p => p.PlayerIndex == pi.playerIndex))
        {
            playerConfigs.Add(new PlayerConfiguration(pi));
            pi.GetComponent<PlayerSetupConfiguration01>().InitializePlayerConfiguration(_parentCanvas, playerConfigs[pi.playerIndex]);
        }
    }

    public bool ReadyPlayer(int index)
    {
        playerConfigs[index].PlayerProfil.IsReady = !playerConfigs[index].PlayerProfil.IsReady;
        if (playerConfigs.All(p => p.PlayerProfil.IsReady == true))
        {
            SceneManager.LoadScene(_gameParametreData.Map);
        }
        return playerConfigs[index].PlayerProfil.IsReady;
    }
}
