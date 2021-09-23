namespace DuelMastersModels.Abilities.TriggeredAbilities
{
    public abstract class TriggerCondition : ICopyable<TriggerCondition>
    {
        public abstract TriggerCondition Copy();
    }

    internal class AtTheEndOfTurn : TriggerCondition
    {
        internal Turn Turn { get; }

        internal AtTheEndOfTurn(Turn turn)
        {
            Turn = turn;
        }

        public override TriggerCondition Copy()
        {
            return new AtTheEndOfTurn(Turn);
        }
    }
}
