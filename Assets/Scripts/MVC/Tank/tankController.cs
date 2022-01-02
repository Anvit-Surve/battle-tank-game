using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankController
{
    public tankController(tankModel tankModel, tankView tankPrefab)
    {
        TankModel = tankModel;
        TankView = GameObject.Instantiate<tankView>(tankPrefab);
    }

    public tankModel TankModel { get; }
    public tankView TankView { get; }
}
