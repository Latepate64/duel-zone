using Cards.OneShotEffects;

namespace Cards.Cards.DM04
{
    class MongrelMan : Creature
    {
        public MongrelMan() : base("Mongrel Man", 5, 2000, Engine.Subtype.Hedrian, Engine.Civilization.Darkness)
        {
            AddTriggeredAbility(new TriggeredAbilities.WheneverAnotherCreatureIsDestroyedAbility(new YouMayDrawCardsEffect(1)));
        }
    }
}
