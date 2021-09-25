namespace DuelMastersModels.Abilities.TriggeredAbilities
{
    public abstract class TriggerCondition : ICopyable<TriggerCondition>
    {
        public abstract TriggerCondition Copy();
    }

    internal class AtTheEndOfTurn : TriggerCondition
    {
        internal System.Guid Turn { get; }

        internal AtTheEndOfTurn(System.Guid turn)
        {
            Turn = turn;
        }

        public override TriggerCondition Copy()
        {
            return new AtTheEndOfTurn(Turn);
        }
    }
}
