using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingletonGeneric<T> : MonoBehaviour where T: MonoSingletonGeneric<T>
{
    private static T instance;
    public static T Instance { get { return instance; } }
    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = (T)this;
        }
        else
        {
            Debug.LogError("Duplicaation of Singleton");
            Destroy(this);
        }
    }
    public class playerTank : MonoSingletonGeneric<playerTank>
    {
        protected override void Awake()
        {
            base.Awake();
        }
    }
    public class enemyTank : MonoSingletonGeneric<enemyTank>
    {

    }
}
