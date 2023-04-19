using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    [SerializeField] PlayerController controller;
   
     [SerializeField] Renderer renderer;

    string id;
    // Start is called before the first frame update
    void Start()
    {
        Shader.PropertyToID(id);
    }

    // Update is called once per frame
    void Update()
    {
        ColorPicker();
    }

    private void ColorPicker()
    {
        if (controller.playerOne)
            renderer.material.color = Color.blue;

        if (controller.playerTwo)
            return;
        if (controller.playerThree)
            renderer.material.color= Color.yellow;
        if (controller. playerFour)
            renderer.material.color = Color.red;
    }
}
