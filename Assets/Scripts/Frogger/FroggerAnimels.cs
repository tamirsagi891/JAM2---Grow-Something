using UnityEngine;

public class FroggerAnimels : MonoBehaviour
{
    #region Fields

    [Range(0, 150)] [SerializeField] private float fastParamter;
    [SerializeField] private float radius;
    [SerializeField] private Vector3 centre;
    private float _angle;
    [SerializeField] [Range(0, 1)] private float waveSpeed;

    #endregion

    private void FixedUpdate()
    {
        //this code make the bird circular movement, and in wave way
        _angle = fastParamter * Time.deltaTime;
        transform.RotateAround(centre, Vector3.forward, _angle);
        waveSpeed = 0.5f;
        transform.position = centre + transform.up * (radius + waveSpeed * Mathf.Sin(Time.time));
    }
    
}