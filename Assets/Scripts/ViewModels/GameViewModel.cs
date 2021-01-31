using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameViewModel : MonoBehaviour
{
    [SerializeField] int objectsAmount;
    [SerializeField] GameObject startPanel;
    [SerializeField] MoveController mover;
    [SerializeField] FallingObject fallingObjectPrefab;
    [SerializeField] Transform fallingObjectsParent;
    [SerializeField] ScoresViewModel scoresViewModel;
    private List<FallingObject> fallingObjectsList = new List<FallingObject>();

    public event Action<bool> OnGameStateChanged;

    void Start()
    {
        mover.OnFallingObjectCollision += Mover_OnFallingObjectCollision;
        GenerateFallingObjects();
        ActivateMenu();
        scoresViewModel.ResetScores();
    }

    private void Mover_OnFallingObjectCollision()
    {
        EndGame();
    }

    public void StartGame()
    {
        scoresViewModel.ResetScores();
        DisableMenu();
        mover.Flag = true;
        foreach(var obj in fallingObjectsList)
        {
            obj.StartMove();
        }
    }
    public void EndGame()
    {
        ActivateMenu();
        mover.Flag = false;
        mover.StopObject();
        foreach (var obj in fallingObjectsList)
        {
            obj.EndMove();
        }
    }

    private void GenerateFallingObjects()
    {
        for(int i = 0; i < objectsAmount; i++)
        {
            var fallingObj = Instantiate(fallingObjectPrefab,new Vector3(0,0,0), Quaternion.identity, fallingObjectsParent);
            fallingObj.EndMove();
            fallingObj.name = "FallingObject" + (i + 1);
            fallingObjectsList.Add(fallingObj);
        }
        scoresViewModel.SetFaliingObjects(fallingObjectsList);
    }

    void ActivateMenu()
    {
        startPanel.SetActive(true);
    }

    void DisableMenu()
    {
        startPanel.SetActive(false);
    }
}
