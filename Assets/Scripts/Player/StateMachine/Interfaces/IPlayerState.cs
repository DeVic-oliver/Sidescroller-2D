public interface IPlayerState
{
    public void OnStateEnter(PlayerStateMachine stateMachineManager);
    public void OnStateUpdate(PlayerStateMachine stateMachineManager);
}
