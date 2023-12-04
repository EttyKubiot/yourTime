using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProggresBar : MonoBehaviour
{
    private GameManager gameManager;
   
    [SerializeField] private Slider slider;

    
        private void Awake()
        {
            gameManager = FindObjectOfType<GameManager>();
            gameManager.OnNewState += SetHaelthSlider;

        }


    private void SetHaelthSlider(float game)
    {
        Debug.Log(game);
        slider.value = game;

    }
}
