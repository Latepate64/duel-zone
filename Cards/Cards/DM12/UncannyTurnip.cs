using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM12
{
    class UncannyTurnip : WaveStrikerCreature
    {
        public UncannyTurnip() : base("Uncanny Turnip", 2, 1000, Race.WildVeggies, Civilization.Nature)
        {
            AddWaveStrikerAbility(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new UncannyTurnipEffect()));
        }
    }

    class UncannyTurnipEffect : OneShotEffect
    {
        public override void Apply(IGame game, IAbility source)
        {
            var controller = source.GetController(game);
            controller.PutFromTopOfDeckIntoManaZone(game, 1, source);
            controller.ReturnOwnManaCreature(game, source);
        }

        public override IOneShotEffect Copy()
        {
            return new UncannyTurnipEffect();
        }

        public override string ToString()
        {
            return "Put the top card of your deck into your mana zone. Then put a creature from your mana zone into your hand.";
        }
    }
}
