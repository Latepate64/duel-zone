namespace DuelMastersModels.Abilities.TriggeredAbilities
{
    public abstract class TriggerCondition : ICopyable<TriggerCondition>
    {
        public virtual bool CanTrigger(Duel duel)
        {
            return true;
        }

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

        public override bool CanTrigger(Duel duel)
        {
            return duel.CurrentTurn.Id == Turn;
        }
    }
}
