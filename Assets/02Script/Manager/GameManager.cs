using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    IInputHandler curInputSystem;
    private PlayerController pc;
    private ProjectileManager pm;



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

        pm = FindAnyObjectByType<ProjectileManager>();
        if (pm == null)
        {
            Debug.Log("GameManager.cs - LoadSceneInit - ProjectileManager 참조실패");
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

    private void FixedUpdate() {
        pc?.FixedUpdateGame(curInputSystem.GetInput());
    }


    IEnumerator StartGame() {
        yield return null;
        
        pc.StartGame(); //플레이어
    
    }
}
