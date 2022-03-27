using Cards.OneShotEffects;
using Common;
using Engine;
using Engine.Abilities;

namespace Cards.Cards.DM06
{
    class AdomisTheOracle : Creature
    {
        public AdomisTheOracle() : base("Adomis, the Oracle", 3, 2000, Subtype.LightBringer, Civilization.Light)
        {
            AddAbilities(new TapAbility(new AdomisTheOracleEffect()));
        }
    }

    class AdomisTheOracleEffect : CardSelectionEffect
    {
        public AdomisTheOracleEffect() : base(new CardFilters.OpponentsShieldZoneCardFilter(), 1, 1, true)
        {
        }

        public AdomisTheOracleEffect(AdomisTheOracleEffect effect) : base(effect)
        {
        }

        public override IOneShotEffect Copy()
        {
            return new AdomisTheOracleEffect();
        }

        public override string ToString()
        {
            return "Choose a shield and look at it. Then put it back where it was.";
        }

        protected override void Apply(IGame game, IAbility source, params Engine.ICard[] cards)
        {
            var player = game.GetPlayer(source.Controller);
            if (player != null)
            {
                var opponent = game.GetOpponent(player);
                if (opponent != null)
                {
                    player.Look(opponent, game, cards);
                    opponent.Unreveal(cards);
                }
            }
        }
    }
}
