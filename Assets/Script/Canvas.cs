using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    [SerializeField] private GameObject controllerButtonsUI;
    [SerializeField] private GameObject finishUI;

    [SerializeField] private Button buttonMainMenu;
    

    private void Start()
    {
        controllerButtonsUI.SetActive(true);
        finishUI.SetActive(false);
        Finish.Instan.OnFinish += Finish_OnFinish;
        buttonMainMenu.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
        });

    }

    private void Finish_OnFinish(object sender, System.EventArgs e)
    {
        controllerButtonsUI.SetActive(false);
        finishUI.SetActive(true);
    }
}
