using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM10
{
    class NecrodragonBryzenaga : Creature
    {
        public NecrodragonBryzenaga() : base("Necrodragon Bryzenaga", 6, 9000, Race.ZombieDragon, Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new NecrodragonBryzenagaEffect());
            AddDoubleBreakerAbility();
        }
    }

    class NecrodragonBryzenagaEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            game.PutFromShieldZoneToHand(Controller.ShieldZone.Cards, true, Source);
        }

        public override IOneShotEffect Copy()
        {
            return new NecrodragonBryzenagaEffect();
        }

        public override string ToString()
        {
            return "Put all your shields into your hand.";
        }
    }
}
