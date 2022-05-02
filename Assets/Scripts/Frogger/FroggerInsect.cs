using UnityEngine;

public class FroggerInsect : MonoBehaviour
{
    [Range(0, 150)] [SerializeField] private float fastParameter;
    [SerializeField] private Vector3 centre;
    private float _angle;

    // Update is called once per frame
    private void FixedUpdate()
    {
        //this code make the insect circular movement
        _angle = fastParameter * Time.deltaTime ;
        transform.RotateAround(centre, Vector3.forward, _angle);
    }
    
}