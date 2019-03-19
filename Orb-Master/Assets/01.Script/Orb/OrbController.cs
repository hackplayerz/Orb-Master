using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class OrbController : MonoBehaviour
{

    [SerializeField] private float _distance;
    [SerializeField][Range(0,5f)] private float _speed;
    [SerializeField] private Transform _targetTrasnform;

    private Vector3 _rotation;
    private float _radian = 0;

    void Start () {
        StartCoroutine (MoveCircle ());
    }

    IEnumerator MoveCircle () {
        while (true) {
            yield return new WaitForEndOfFrame ();
            transform.position = new Vector3 (Mathf.Sin (_radian) * _distance, Mathf.Cos (_radian) * _distance, 0);
            _radian += _speed * Time.fixedDeltaTime;
        }
    }
}
