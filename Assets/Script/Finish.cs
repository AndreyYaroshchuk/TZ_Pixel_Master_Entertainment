using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private const string TAG_CARS = "Cars";

    public event EventHandler OnFinish;

    public static Finish Instan;

    private void Awake()
    {
        Instan  = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TAG_CARS))
        {
            OnFinish?.Invoke(this, EventArgs.Empty);
        }
    }
}
