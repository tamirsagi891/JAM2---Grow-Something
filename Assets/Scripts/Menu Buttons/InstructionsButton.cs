using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsButton : MonoBehaviour
{
    private void Update()
    {
        if (Input.anyKey) SceneManager.LoadScene("Start");
    }
}