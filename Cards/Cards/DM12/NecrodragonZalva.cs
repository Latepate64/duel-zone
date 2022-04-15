using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM12
{
    class NecrodragonZalva : Creature
    {
        public NecrodragonZalva() : base("Necrodragon Zalva", 4, 5000, Subtype.ZombieDragon, Civilization.Darkness)
        {
            AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(new NecrodragonZalvaEffect());
        }
    }

    class NecrodragonZalvaEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            source.GetOpponent(game).DrawCards(1, game);
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new NecrodragonZalvaEffect();
        }

        public override string ToString()
        {
            return "Your opponent draws a card.";
        }
    }
}
