﻿namespace Code.Infrastucture.GmaeStateMachine
{
    public interface IState : IExitableState
    {
        void Enter();
    }
    
    public interface IPayloadState<TPayload> : IExitableState
    {
        void Enter(TPayload payload);
    }
    
    public interface IExitableState
    {
        void Exit();
    }
}