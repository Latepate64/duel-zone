using Common;

namespace Cards.Cards.DM04
{
    class SmileAngler : Creature
    {
        public SmileAngler() : base("Smile Angler", 6, 3000, Subtype.GelFish, Civilization.Water)
        {
            AddAbilities(new TriggeredAbilities.AttackAbility(new OneShotEffects.OpponentManaRecoveryEffect(0, 1, true)));
        }
    }
}
