using TriggeredAbilities;
using OneShotEffects;
using Abilities.Static;

namespace Cards.Promo
{
    sealed class VelyrikaDragon : Creature
    {
        public VelyrikaDragon() : base("Velyrika Dragon", 7, 7000, Interfaces.Race.ArmoredDragon, Interfaces.Civilization.Fire)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new SearchRaceCreatureEffect(
                Interfaces.Race.ArmoredDragon)));
            AddAbilities(new DoubleBreakerAbility());
        }
    }
}
