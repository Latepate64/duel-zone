using Cards.OneShotEffects;
using Common;

namespace Cards.Cards.DM04
{
    class MongrelMan : Creature
    {
        public MongrelMan() : base("Mongrel Man", 5, 2000, Engine.Subtype.Hedrian, Civilization.Darkness)
        {
            AddTriggeredAbility(new TriggeredAbilities.WheneverAnotherCreatureIsDestroyedAbility(new YouMayDrawCardsEffect(1)));
        }
    }
}
