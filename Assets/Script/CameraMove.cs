using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private const string FILE_SELECT_CARS = "selectCars";

    [SerializeField] private RCC_Camera rCC_Camera;

    [SerializeField] private List<RCC_CarControllerV3> listRCCCarControllerV3;

    private int indexList;
    private void Awake()
    {
        indexList = PlayerPrefs.GetInt(FILE_SELECT_CARS);
    }
    private void Start()
    {
        listRCCCarControllerV3[indexList].gameObject.SetActive(true);
        rCC_Camera.playerCar = listRCCCarControllerV3[indexList];
    }
}
