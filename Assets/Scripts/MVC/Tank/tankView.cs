using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankView : MonoBehaviour
{
    public CharacterController controller { get; set; }
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
}
