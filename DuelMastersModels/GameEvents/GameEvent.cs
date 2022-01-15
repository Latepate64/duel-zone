namespace DuelMastersModels.GameEvents
{
    public abstract class GameEvent
    {
        public virtual void Apply(Duel duel)
        {
        }

        public abstract string ToString(Duel duel);

        public virtual GameEvent Copy() { return null; }
    }
}
