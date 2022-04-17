using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM08
{
    class GrapeGlobbo : Creature
    {
        public GrapeGlobbo() : base("Grape Globbo", 2, 1000, Race.CyberVirus, Civilization.Water)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new LookAtYourOpponentsHandEffect());
        }
    }

    class LookAtYourOpponentsHandEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            source.GetController(game).LookAtOpponentsHand(game);
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new LookAtYourOpponentsHandEffect();
        }

        public override string ToString()
        {
            return "Look at your opponent's hand.";
        }
    }
}
