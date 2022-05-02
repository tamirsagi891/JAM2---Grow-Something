using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreUI : MonoBehaviour
{
    [SerializeField] GameObject highscoreUIElementPrefab;
    [SerializeField] Transform elementWrapper;

    List<GameObject> uiElements = new List<GameObject> ();
    

    private void OnEnable () {
        HighScoreHandler.onHighScoreListChanged += UpdateUI;
    }

    private void OnDisable () {
        HighScoreHandler.onHighScoreListChanged -= UpdateUI;
    }
    
    private void UpdateUI (List<HighScoreElement> list) {
        for (int i = 0; i < list.Count; i++) {
            HighScoreElement el = list[i];

            if (el != null && el.points > 0) 
            {
                if (i >= uiElements.Count)
                {
                    // instantiate new entry
                    var inst = Instantiate (highscoreUIElementPrefab, Vector3.zero, Quaternion.identity);
                    inst.transform.SetParent (elementWrapper, false);

                    uiElements.Add (inst);
                }

                // write or overwrite name & points
                
                var texts = uiElements[i].GetComponentsInChildren<TextMeshProUGUI> ();
                texts[0].text = el.playerName;
                texts[1].text = el.points.ToString ();
            }
        }
    }
}
