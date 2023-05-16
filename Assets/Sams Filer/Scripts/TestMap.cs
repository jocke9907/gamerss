using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMap : MonoBehaviour
{
    public int countdownDuration = 5;
    public GameObject[] pillars;
    public int requiredPlayersOnPillar = 1; // Number of players required on a pillar to start the countdown

    private int[] votes;
    private bool[] playersOnPillar;
    private Coroutine countdownCoroutine;

    private void Start()
    {
        InitializeVotes();
        InitializePlayersOnPillar();
    }

    private void InitializeVotes()
    {
        votes = new int[pillars.Length];
        for (int i = 0; i < pillars.Length; i++)
        {
            votes[i] = 0;
        }
    }

    private void InitializePlayersOnPillar()
    {
        playersOnPillar = new bool[pillars.Length];
        for (int i = 0; i < pillars.Length; i++)
        {
            playersOnPillar[i] = false;
        }
    }

    private IEnumerator Countdown()
    {
        int remainingTime = countdownDuration;
        while (remainingTime > 0)
        {
            yield return new WaitForSeconds(1);
            remainingTime--;
            Debug.Log("Countdown: " + remainingTime + " seconds");
        }

        int chosenPillarIndex = ChoosePillar();
        Debug.Log("Chosen Pillar: " + chosenPillarIndex);

        // Do something with the chosen pillar, like loading a new scene
    }

    private int ChoosePillar()
    {
        int totalVotes = 0;
        foreach (int vote in votes)
        {
            totalVotes += vote;
        }

        float randomValue = Random.Range(0f, totalVotes);
        float cumulativeVotes = 0f;

        for (int i = 0; i < votes.Length; i++)
        {
            cumulativeVotes += votes[i];
            if (randomValue <= cumulativeVotes)
            {
                return i;
            }
        }

        return -1; // Return -1 if there's an error
    }

    public void PlayerOnPillar(int pillarIndex)
    {
        votes[pillarIndex]++;
        playersOnPillar[pillarIndex] = true;

        if (countdownCoroutine == null && CheckIfCountdownStart())
        {
            countdownCoroutine = StartCoroutine(Countdown());
        }
    }

    public void PlayerLeftPillar(int pillarIndex)
    {
        votes[pillarIndex]--;
        playersOnPillar[pillarIndex] = false;

        if (countdownCoroutine != null && !CheckIfCountdownStart())
        {
            StopCoroutine(countdownCoroutine);
            countdownCoroutine = null;
        }
    }

    private bool CheckIfCountdownStart()
    {
        int playersOnPillarCount = 0;
        foreach (bool isPlayerOnPillar in playersOnPillar)
        {
            if (isPlayerOnPillar)
            {
                playersOnPillarCount++;
                if (playersOnPillarCount >= requiredPlayersOnPillar)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
