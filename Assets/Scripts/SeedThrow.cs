using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SeedThrow : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] private bool resetArrowPos = false;
    [Range(0, 1)] [SerializeField] private float seedSizeScaler = 1f;
    [Range(1, 50)] [SerializeField] private float speedScaler = 15;
    [Range(10, 20)] [SerializeField] private float targetSpeed = 10f;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject garden;
    [SerializeField] private List<GameObject> plants = new List<GameObject>(2);
    private Vector3 _targetBasePos, _arrowBasePos;
    private bool _rotateArrow = false;
    private int _arrowDirection = 1; // 1=right -1=left
    private bool _sendTarget = false;
    private int _targetDirection = 1; // 1=up -1=down

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _targetBasePos = target.transform.localPosition;
        _arrowBasePos = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) ButtonPressed();
    }

    private void FixedUpdate()
    {
        if (_rotateArrow && !_sendTarget) RotateArrow();

        if (_sendTarget) SendTarget();
    }

    private void ButtonPressed()
    {
        _gameManager.IsTrowingSeed = true;
        if (!_rotateArrow && !_sendTarget)
        {
            _rotateArrow = true;
            _gameManager.AudioManager.PlaySound("Throw");
        }
        else if (!_sendTarget) _sendTarget = true;
        else
        {
            if (CheckTarget()) PlantSeed();
            else PopSeed();
            ResetArrow();
        }
    }

    private void RotateArrow()
    {
        var rot = transform.rotation;
        if (Math.Abs(rot.z) > 0.6f) _arrowDirection *= -1;
        transform.rotation = rot * Quaternion.Euler(0, 0, _arrowDirection * speedScaler * 10 * Time.deltaTime);
    }

    private void SendTarget()
    {
        var targetPos = target.transform.localPosition;
        if (targetPos.y > 28)
        {
            targetPos.y = 28;
            _targetDirection *= -1;
        }

        if (targetPos.y < 12)
        {
            targetPos.y = 12;
            _targetDirection *= -1;
        }

        target.transform.localPosition = targetPos;
        target.transform.position += _targetDirection * transform.up * targetSpeed / 100;
    }

    private void ResetArrow()
    {
        _gameManager.IsTrowingSeed = false;
        target.transform.localPosition = _targetBasePos;
        if (resetArrowPos) transform.rotation = Quaternion.identity;
        if (Random.Range(0, 2) == 0)
            _arrowDirection = 1;
        else
            _arrowDirection = -1;
        _targetDirection = 1;
        _rotateArrow = _sendTarget = false;
    }

    private bool CheckTarget()
    {
        var pos = target.transform.position;
        target.SetActive(false);
        var intersecting = Physics2D.OverlapCircleAll(pos, seedSizeScaler);
        target.SetActive(true);
        if (intersecting.Length > 0)
            return intersecting.Length == 1 && intersecting[0].gameObject.CompareTag("Ground");
        return false;
    }

    private void PlantSeed()
    {
        _gameManager.AudioManager.PlaySound("Planted");
        var pos = target.transform.position;
        var newPlant = Instantiate(plants[Random.Range(1, plants.Count)], pos, transform.rotation, garden.transform);
        pos = newPlant.transform.localPosition; // next three lines explanation:
        pos.z = target.transform.localPosition.y / 3; // meant to plant that are closer to the centre of the world
        newPlant.transform.localPosition = pos; // wont overlap with those behind them
        _gameManager.Score += 1;
    }

    private void PopSeed()
    {
        _gameManager.AudioManager.PlaySound("Missed");
        var pos = target.transform.position;
        var tempSeed = Instantiate(plants[0], pos, transform.rotation, garden.transform);
        Destroy(tempSeed, 1);
    }
}