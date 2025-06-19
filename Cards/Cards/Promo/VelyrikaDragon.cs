using Cards.ContinuousEffects;
using Cards.TriggeredAbilities;

namespace Cards.Cards.Promo
{
    class VelyrikaDragon : Creature
    {
        public VelyrikaDragon() : base("Velyrika Dragon", 7, 7000, Engine.Race.ArmoredDragon, Engine.Civilization.Fire)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new OneShotEffects.SearchRaceCreatureEffect(Engine.Race.ArmoredDragon)));
            AddStaticAbilities(new DoubleBreakerEffect());
        }
    }
}
