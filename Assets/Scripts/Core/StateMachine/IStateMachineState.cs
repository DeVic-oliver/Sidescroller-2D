public interface IStateMachineState
{
    public void OnStateEnter(IStateMachineManager stateMachineManager);
    public void OnStateUpdate(IStateMachineManager stateMachineManager);
}
