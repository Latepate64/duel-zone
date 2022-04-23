using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM12
{
    class NecrodragonZalva : Creature
    {
        public NecrodragonZalva() : base("Necrodragon Zalva", 4, 5000, Race.ZombieDragon, Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new NecrodragonZalvaEffect());
        }
    }

    class NecrodragonZalvaEffect : OneShotEffect
    {
        public NecrodragonZalvaEffect()
        {
        }

        public NecrodragonZalvaEffect(IOneShotEffect effect) : base(effect)
        {
        }

        public override void Apply(IGame game)
        {
            GetOpponent(game).DrawCards(1, game, Ability);
        }

        public override IOneShotEffect Copy()
        {
            return new NecrodragonZalvaEffect(this);
        }

        public override string ToString()
        {
            return "Your opponent draws a card.";
        }
    }
}
