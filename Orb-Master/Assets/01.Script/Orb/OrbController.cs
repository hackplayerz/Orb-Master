using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class OrbController : MonoBehaviour
{

    private float _distance;
    private Vector3 _targetPosition;

    private float _speed;
    [HideInInspector] public float radian = 0;
    
    void Start ()
    {
        transform.position = (transform.position - _targetPosition).normalized * _distance;
        StartCoroutine (MoveCircle ());
    }

    IEnumerator MoveCircle () 
    {
        while (true)
        {
            _speed = GameManager.Instance.orbSpeed;
            yield return new WaitForEndOfFrame ();
            transform.position = new Vector3(Mathf.Sin(radian), Mathf.Cos(radian), 0) * _distance + _targetPosition;
            radian += _speed * Time.fixedDeltaTime;
        }
    }
    
    /// <summary>
    /// Set Orb Preset
    /// </summary>
    /// <param name="targetPosition">Rotating Target Middle Position</param>
    /// <param name="distance">From Target distance</param>
    /// <param name="startDegree">Start Rotation radian</param>
    public void SetOrb(Vector3 targetPosition, float distance, float startDegree)
    {
        _targetPosition = targetPosition;
        _distance = distance;
        radian = startDegree * Mathf.Deg2Rad;
    }
}
