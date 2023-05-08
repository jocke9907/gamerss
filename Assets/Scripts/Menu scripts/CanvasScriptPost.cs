using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class CanvasScriptPost : MonoBehaviour
{
    PlayerController playerController;
    BomberManger bomberManger;
    RandomMap randomMap;
    public TextMeshProUGUI nextMap;
    public void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        bomberManger = FindObjectOfType<BomberManger>();
        randomMap = FindObjectOfType<RandomMap>();
    }
    void Update()
    {
        ShowNexMap();
    }
    public void ShowNexMap()
    {
        if(randomMap.randMap == 1)
        {
            nextMap.text = "The next map is Ground is Falling. ";
        }
        if (randomMap.randMap == 2)
        {
            nextMap.text = "The next map is Bomber. ";
        }
        if (randomMap.randMap == 3)
        {
            nextMap.text = "The next map is The Maze. ";
        }
        if (randomMap.randMap == 4)
        {
            nextMap.text = "The next map is Wall Climer. ";
        }
        if (randomMap.randMap == 5)
        {
            nextMap.text = "The next map is Ground is Lava. ";
        }
        if (randomMap.randMap == 6)
        {
            nextMap.text = "The next map is Capture the Flag. ";
        }
        if (randomMap.randMap == 7)
        {
            nextMap.text = "The next map is Spinning Wheel. ";
        }

    }
}
