using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineFreeLook))]
public class CameraLook : MonoBehaviour
{
    [SerializeField]
    private float lookSpeed = 1;
    private CinemachineFreeLook cinemachine;
    private Tank tankInput;

    private void Awake(){
        tankInput = new Tank();
        cinemachine = GetComponent<CinemachineFreeLook>();
    }
    private void OnEnable(){
        tankInput.Enable();
    }
    private void OnDisable(){
        tankInput.Disable();
    }
    void Update(){
        Vector2 delta = tankInput.PlayerMain.Look.ReadValue<Vector2>();
        cinemachine.m_XAxis.Value += delta.x * 200 * lookSpeed * Time.deltaTime;
        cinemachine.m_YAxis.Value += delta.y * lookSpeed * Time.deltaTime;
    }
}
