using TriggeredAbilities;
using ContinuousEffects;
using OneShotEffects;

namespace Cards.Promo
{
    class VelyrikaDragon : Engine.Creature
    {
        public VelyrikaDragon() : base("Velyrika Dragon", 7, 7000, Interfaces.Race.ArmoredDragon, Interfaces.Civilization.Fire)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new SearchRaceCreatureEffect(
                Interfaces.Race.ArmoredDragon)));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
