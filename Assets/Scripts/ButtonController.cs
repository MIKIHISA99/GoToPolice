using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour, IPointerClickHandler
{
    public String tagButton;
    public GameObject backgroundButton;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (tagButton == "Start")
        {
            var lvlController = FindObjectOfType<LevelController>();
            lvlController.StartGame();
            backgroundButton.SetActive(false);
            this.gameObject.SetActive(false);
        }
        if (tagButton == "Restart")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }    
    }
}
