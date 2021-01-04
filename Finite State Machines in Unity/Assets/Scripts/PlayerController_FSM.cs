using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_FSM : MonoBehaviour
{
    #region Player Variables

    private PlayerBaseState currentState; 
    
    public PlayerBaseState CurrentState{
        get { return currentState; }
    }
    public float jumpForce;
    public Transform head;
    public Transform weapon01;
    public Transform weapon02;

    public Sprite idleSprite;
    public Sprite duckingSprite;
    public Sprite jumpingSprite;
    public Sprite spinningSprite;

    private SpriteRenderer face;
    private Rigidbody rbody;


    public Rigidbody Rigidbody
    {
        get { return rbody; }
    }

    public readonly PlayerIDLEState iDLEState = new PlayerIDLEState();
    public readonly PlayerDuckingState duckingState = new PlayerDuckingState();
    public readonly PlayerJumpingState jumpingState = new PlayerJumpingState(); 

    #endregion

    private void Awake()
    {
        face = GetComponentInChildren<SpriteRenderer>();
        rbody = GetComponent<Rigidbody>();
        SetExpression(idleSprite);
    }
    private void Start() {
    
        TransitionToState(iDLEState);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Update(this);
    }

    public void TransitionToState(PlayerBaseState state)
    {
        currentState = state; 
        currentState.EnterState(this);
    }

    private void OnCollisionEnter(Collision other) {
        currentState.OnCollisionEnter(this);
    }

    public void SetExpression(Sprite newExpression)
    {
        face.sprite = newExpression;
    }
}
