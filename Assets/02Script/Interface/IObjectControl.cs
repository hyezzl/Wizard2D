using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectControl
{
    public void StartGame();

    public void StopGame();

    public void RestartGame();

    public void ResumeGame();

    public void UpdateGame(Vector2 newDir);

    public void DirUpdate(int key);

}
