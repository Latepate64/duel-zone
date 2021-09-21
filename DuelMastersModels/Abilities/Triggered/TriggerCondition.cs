namespace DuelMastersModels.Abilities.TriggeredAbilities
{
    public abstract class TriggerCondition
    {
    }

    internal class AtTheEndOfTurn : TriggerCondition
    {
        internal Turn Turn { get; }

        internal AtTheEndOfTurn(Turn turn)
        {
            Turn = turn;
        }
    }
}
