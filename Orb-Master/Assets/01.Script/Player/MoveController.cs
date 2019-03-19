using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    
    #region SerializedField

    [Range(1,10f)][SerializeField] private float _speed;
    
    #endregion

    #region MainProcessor

    private void Update()
    {
        Move();
    }

    #endregion

    /// <summary>
    /// Move Object
    /// </summary>
    void Move()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        
        transform.position += new Vector3(inputX,inputY,0) * _speed * Time.deltaTime; // Translate Object
        if (inputX > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (inputX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

}
