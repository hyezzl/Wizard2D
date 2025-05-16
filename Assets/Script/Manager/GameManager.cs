using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    IInputHandler curInputSystem;
    private PlayerController pc;



    protected override void DoAwake()
    {
        SceneManager.sceneLoaded += LoadSceneInit;
    }

    private void LoadSceneInit(Scene newScene, LoadSceneMode sceneMode) {
        if (!TryGetComponent<IInputHandler>(out curInputSystem)) {
            Debug.Log("GameManager.cs - LoadSceneInit - curInputSystem 참조실패");
        }
        
        pc = FindAnyObjectByType<PlayerController>();
        if (pc == null) {
            Debug.Log("GameManager.cs - LoadSceneInit - PlayerManager 참조실패");
        }
    
    }

    private void Start()
    {
        StartCoroutine(StartGame());
    }

    private void Update()
    {
        if (curInputSystem != null) {
            pc?.UpdateGame(curInputSystem.GetInput());
            pc?.DirUpdate(curInputSystem.GetDir());
        }
    }

    IEnumerator StartGame() {
        yield return null;
        
        pc.StartGame(); //플레이어
    
    }
}
