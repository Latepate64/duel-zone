using DuelMastersCards.OneShotEffects;
using DuelMastersCards.StaticAbilities;
using DuelMastersModels;

namespace DuelMastersCards.Cards.DM01
{
    class Gigaberos : Creature
    {
        public Gigaberos() : base("Gigaberos", 5, Civilization.Darkness, 8000, Subtype.Chimera)
        {
            // When you put this creature into the battle zone, destroy 2 of your other creatures or destroy this creature.
            Abilities.Add(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new GigaberosEffect()));
            Abilities.Add(new DoubleBreakerAbility());
        }
    }
}
