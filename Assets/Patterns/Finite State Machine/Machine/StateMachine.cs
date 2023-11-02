using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private List<State<T>> _states;
    private Dictionary<Type, State<T>> _typeDictionary = new ();
    private State<T> _activeState;

    private void Awake()
    {
        _states.ForEach((s) => _typeDictionary.Add(s.GetType(), s));
        SetState(_states[0].GetType());
    }

    public void SetState(Type stateType)
    {
        if(_activeState != null)
            _activeState.Exit();
        _activeState = _typeDictionary[stateType];
        _activeState.Init(GetComponent<T>());
    }

    private void Update()
    {
        _activeState.CaptureInput();
        _activeState.Update();
        _activeState.ChangeState();
    }

    private void FixedUpdate()
    {
        _activeState.FixedUpdate();
    }
}
