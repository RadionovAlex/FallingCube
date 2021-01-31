using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoresViewModel : MonoBehaviour
{
    private List<FallingObject> fallingObjects;
    private int scores = 0;

    [SerializeField] Text scoresText;
    public void SetFaliingObjects(List<FallingObject> list)
    {
        fallingObjects = list;

        foreach(var c in fallingObjects)
        {
            c.OnFalled += C_OnFalled;
        }
    }

    public void ResetScores()
    {
        scores = 0;
        scoresText.text = "";
    }

    private void C_OnFalled()
    {
        scores++;
        scoresText.text = scores.ToString();
    }

    
}
