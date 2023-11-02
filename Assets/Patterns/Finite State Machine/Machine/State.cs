﻿using UnityEngine;

public abstract class State <T> : ScriptableObject where T : MonoBehaviour
{
    protected T _runner;

    public virtual void Init(T parent)
    {
        _runner = parent;
    }

    public abstract void CaptureInput();

    public abstract void Update();
    
    public abstract void FixedUpdate();
    
    public abstract void ChangeState();

    public abstract void Exit();
}
