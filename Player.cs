using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

public float speed;
public float runSpeed = 6;

private float inicialSpeed;
private bool _isRunning;
private Rigidbody2D rig;
private Vector2 _direction;

public Vector2 direction
{
    get { return _direction; }
    set { _direction = value; }
}

public bool isRunning
{
    get { return _isRunning; }
    set { _isRunning = value; }
}

private void Start() {
    rig = GetComponent<Rigidbody2D>();
    inicialSpeed = speed;
}
private void Update() {
    OnInput();
    OnRun();
}

private void FixedUpdate() {
    OnMove();
}


    #region Movement
    
    void OnInput(){
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove(){
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun(){
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            isRunning = true;

        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
            speed = inicialSpeed;
            isRunning = false;
    }


    #endregion


}
