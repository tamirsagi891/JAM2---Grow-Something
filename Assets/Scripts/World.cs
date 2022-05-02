using System;
using UnityEngine;

public class World : MonoBehaviour
{
    private GameManager _gameManager;
    [Range(20, 150)] [SerializeField] private float fastParameter = 70;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        if(_gameManager.IsTrowingSeed) return;
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            var rot = transform.rotation;
            transform.rotation = rot * Quaternion.Euler(0, 0, -fastParameter * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            var rot = transform.rotation;
            transform.rotation = rot * Quaternion.Euler(0, 0, fastParameter * Time.deltaTime);
        }
    }
}