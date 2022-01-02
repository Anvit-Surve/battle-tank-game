using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankService : MonoSingletonGeneric<tankService>
{
    public tankView tankView;


    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;

    private Tank tankInput;
    private Transform cameraMain;
    private void OnEnable()
    {
        tankInput.Enable();
    }
    private void OnDisable()
    {
        tankInput.Disable();
    }

    protected override void Awake()
    {
        base.Awake();
        tankInput = new Tank();
        
    }

    private void Start()
    {
        cameraMain = Camera.main.transform;
        CreateNewTank();
    }

    private tankController CreateNewTank()
    {
        tankModel model = new tankModel(playerSpeed, 100, jumpHeight);
        tankController tank = new tankController(model, tankView);
        return tank;
    }

    private Vector3 playerVelocity;
    private bool groundedPlayer;

    void Update()
    {
        groundedPlayer = tankView.controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movementInput = tankInput.PlayerMain.Move.ReadValue<Vector2>();
        Vector3 move = (cameraMain.forward * movementInput.y + cameraMain.right * movementInput.x);
        move.y = 0;
        tankView.controller.Move(move * Time.deltaTime * this.playerSpeed);

        if (move != Vector3.zero)
        {
            tankView.gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (tankInput.PlayerMain.Jump.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(this.jumpHeight * -3.0f * -9.8f);
        }

        playerVelocity.y += -9.8f * Time.deltaTime;
        tankView.controller.Move(playerVelocity * Time.deltaTime);
    }

}
