using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankModel
{
    public tankModel(float playerSpeed, float health, float jumpHeight){
        PlayerSpeed = playerSpeed;
        Health = health;
        JumpHeight = jumpHeight;
    }

    public float PlayerSpeed { get; }
    public float Health { get; }
    public float JumpHeight { get; }
}
