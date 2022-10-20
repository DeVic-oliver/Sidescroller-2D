using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    private IPlayerState currentState;
    public PlayerStatus ThePlayerStatus;
    #region CONCRETE STATES
    public IPlayerState AliveState = new PlayerAliveState();
    public IPlayerState DeadState = new PlayerDeadState();
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        Init();
        InitFirstState();
    }
    private void Init()
    {
        ThePlayerStatus = GetComponent<PlayerStatus>();
    }
    private void InitFirstState()
    {
        currentState = AliveState;
        currentState.OnStateEnter(this);
    }
    // Update is called once per frame
    void Update()
    {
        currentState.OnStateUpdate(this);
    }

    public void SwitchState(IPlayerState nextState)
    {
        currentState = nextState;
        currentState.OnStateEnter(this);
    }
}
