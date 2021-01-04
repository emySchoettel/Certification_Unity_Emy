﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIDLEState : PlayerBaseState
{
    public override void EnterState(PlayerController_FSM player)
  {
      player.SetExpression(player.idleSprite);
  }

    public override void Update(PlayerController_FSM player) 
    {
        if(Input.GetButtonDown("Jump"))
        {
            player.Rigidbody.AddForce(Vector3.up * player.jumpForce);
            player.TransitionToState(player.jumpingState);
        }
        if(Input.GetButtonDown("Duck"))
        {
            player.TransitionToState(player.duckingState);
        }
        if(Input.GetButtonDown("SwapWeapon"))
        {
            bool usingWeapon01 = player.weapon01.gameObject.activeInHierarchy;

            player.weapon01.gameObject.SetActive(usingWeapon01 == false);
            player.weapon02.gameObject.SetActive(usingWeapon01);
        }
    }

    public override void OnCollisionEnter(PlayerController_FSM player)
    {       
    }
}
