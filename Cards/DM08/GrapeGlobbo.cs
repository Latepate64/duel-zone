using TriggeredAbilities;
using Engine;
using Engine.Abilities;
using Interfaces;

namespace Cards.DM08
{
    class GrapeGlobbo : Creature
    {
        public GrapeGlobbo() : base("Grape Globbo", 2, 1000, Race.CyberVirus, Civilization.Water)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(new LookAtYourOpponentsHandEffect()));
        }
    }

    class LookAtYourOpponentsHandEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            Controller.LookAtOpponentsHand(game);
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
