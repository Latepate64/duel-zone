using TriggeredAbilities;
using ContinuousEffects;
using OneShotEffects;

namespace Cards.Promo
{
    class VelyrikaDragon : Engine.Creature
    {
        public VelyrikaDragon() : base("Velyrika Dragon", 7, 7000, Engine.Race.ArmoredDragon, Engine.Civilization.Fire)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new SearchRaceCreatureEffect(
                Engine.Race.ArmoredDragon)));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
