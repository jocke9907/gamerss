using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    PlayerScore playerscore;
    // Start is called before the first frame update
    void Start()
    {
        //playerscore.GetComponent<PlayerScore>();
    }

    // Update is called once per frame
    void Update()
    {
        //text.text = playerscore.currentScore.ToString();
    }
}
