using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedMarker : MonoBehaviour
{
    [SerializeField] private MarkerInteract marker;
    [SerializeField] private GameObject visualGameObject;
    private void Start()
    {
        //PlayerController.Instance.OnSelectedMarkerChanged += Instance_OnSelectedMarkerChanged;
    }

    //private void Instance_OnSelectedMarkerChanged(object sender, PlayerController.OnSelectedCounterChangedEventargs e)
    //{
    //    if (e.selectedMarker == marker)
    //    {
    //        Debug.Log("show");
    //        Show();
    //    }
    //    else
    //    {
    //        Debug.Log("hide");
    //        Hide();
    //    }
    //}
    //private void Show()
    //{
    //    visualGameObject.SetActive(true);
    //}
    //private void Hide()
    //{
    //    visualGameObject.SetActive(false);
    //}
}
