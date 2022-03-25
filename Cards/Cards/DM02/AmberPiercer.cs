using Common;

namespace Cards.Cards.DM02
{
    class AmberPiercer : Creature
    {
        public AmberPiercer() : base("Amber Piercer", 4, 2000, Subtype.BrainJacker, Civilization.Darkness)
        {
            // Whenever this creature attacks, you may return a creature from your graveyard to your hand.
            AddAbilities(new TriggeredAbilities.WheneverThisCreatureAttacksAbility(new OneShotEffects.SalvageCreatureEffect(0, 1)));
        }
    }
}
