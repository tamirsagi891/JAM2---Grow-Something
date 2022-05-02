using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class EnterNameScript : MonoBehaviour
{
     private string playerName;
     private GameManager _gameManager;
     [SerializeField] private GameObject inputField;
     [SerializeField] private GameObject textDisplay;
     
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            playerName =  inputField.GetComponent<TextMeshProUGUI>().text;
            _gameManager.PlayerName = playerName;
            textDisplay.GetComponent<TextMeshProUGUI>().text = "Welcome " + playerName + " to The Game";
        }
    }
  

}
