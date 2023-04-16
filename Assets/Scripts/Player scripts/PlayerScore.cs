using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int currentScore = 0;
    
    public void AddPoints(int pointsToAdd)
    {
        currentScore += pointsToAdd;
    }
}
