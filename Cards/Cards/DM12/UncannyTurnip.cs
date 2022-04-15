using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM12
{
    class UncannyTurnip : WaveStrikerCreature
    {
        public UncannyTurnip() : base("Uncanny Turnip", 2, 1000, Subtype.WildVeggies, Civilization.Nature)
        {
            AddWaveStrikerAbility(new TriggeredAbilities.WhenYouPutThisCreatureIntoTheBattleZoneAbility(new UncannyTurnipEffect()));
        }
    }

    class UncannyTurnipEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            source.GetController(game).PutFromTopOfDeckIntoManaZone(game, 1);
            return new OneShotEffects.ReturnCreatureFromYourManaZoneToYourHandEffect().Apply(game, source);
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
