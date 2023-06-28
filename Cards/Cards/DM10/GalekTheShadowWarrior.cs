using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM10
{
    class GalekTheShadowWarrior : Creature
    {
        public GalekTheShadowWarrior() : base("Galek, the Shadow Warrior", 5, 2000, Race.Ghost, Race.Human, Civilization.Darkness, Civilization.Fire)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new GalekTheShadowWarriorEffect());
        }
    }

    class GalekTheShadowWarriorEffect : OneShotEffect
    {
        public override void Apply(IGame game)
        {
            Applier.DestroyOpponentsBlocker(game, Ability);
            Applier.Opponent.DiscardAtRandom(1, Ability);
        }

        public override IOneShotEffect Copy()
        {
            return new GalekTheShadowWarriorEffect();
        }

        public override string ToString()
        {
            return "Destroy one of your opponent's creatures that has \"blocker.\" Then your opponent discards a card at random from his hand.";
        }
    }
}
