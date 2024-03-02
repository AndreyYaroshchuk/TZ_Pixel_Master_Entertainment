using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SelectMachineUI : MonoBehaviour
{
    private const string FILE_SELECT_CARS = "selectCars";

    [SerializeField] private Button buttonNextSelectMachine;
    [SerializeField] private Button buttonBackSelectMachine;
    [SerializeField] private List<GameObject> listCars;
    [SerializeField] private Touchpad touchpad;

    private int idCars = 0;
    private float speedRotation = 2f;
    private float rotationLeft = 30; 
    private float rotationRight = -30;

    private void Start()
    {
        HideCars();
        buttonBackSelectMachine.gameObject.SetActive(false);

        buttonNextSelectMachine.onClick.AddListener(() =>
        {
            listCars[idCars].gameObject.SetActive(false);
            buttonNextSelectMachine.gameObject.SetActive(false);
            buttonBackSelectMachine.gameObject.SetActive(true);
            ++idCars;
            listCars[idCars].gameObject.SetActive(true);
            PlayerPrefs.SetInt(FILE_SELECT_CARS, idCars);
            PlayerPrefs.Save(); 
        });
        buttonBackSelectMachine.onClick.AddListener(() =>
        {
            listCars[idCars].gameObject.SetActive(false);
            buttonBackSelectMachine.gameObject.SetActive(false);
            buttonNextSelectMachine.gameObject.SetActive(true);
            --idCars;
            listCars[idCars].gameObject.SetActive(true);
            PlayerPrefs.SetInt(FILE_SELECT_CARS, idCars);
            PlayerPrefs.Save();
        });
    }

    private void HideCars()
    {
        for (int i = 0; i < listCars.Count; i++)
        {
            listCars[i].gameObject.SetActive(false);
        }
        listCars[0].gameObject.SetActive(true);
        PlayerPrefs.SetInt(FILE_SELECT_CARS, 0);
        PlayerPrefs.Save();
    }

    private void Update()
    {
        if (touchpad.GetDirection().x > 0)
        {
            if (rotationLeft == 360)
            {
                rotationLeft = 30;
            }
            rotationLeft += 1;
            listCars[idCars].transform.rotation = Quaternion.Slerp(listCars[idCars].transform.rotation, Quaternion.Euler(0, rotationLeft, 0), speedRotation * Time.deltaTime);
        }
        else if (touchpad.GetDirection().x < 0)
        {
            if (rotationRight == -360)
            {
                rotationRight = -30;
            }

            rotationRight -= 1;
            listCars[idCars].transform.rotation = Quaternion.Slerp(listCars[idCars].transform.rotation, Quaternion.Euler(0, rotationRight, 0), speedRotation * Time.deltaTime);
        }
    }
}

