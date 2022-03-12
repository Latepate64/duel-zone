using Common;
using Common.GameEvents;
using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.ContinuousEffects
{
    /// <summary>
    /// While you have at least 1 Angel Command in the battle zone, this creature gets +2000 power.
    /// </summary>
    class IocantTheOracleEffect : PowerModifyingEffect
    {
        public IocantTheOracleEffect(IocantTheOracleEffect effect) : base(effect)
        {
        }

        public IocantTheOracleEffect() : base(2000)
        {
        }

        public override ContinuousEffect Copy()
        {
            return new IocantTheOracleEffect(this);
        }

        public override void Apply(Game game)
        {
            foreach (var card in game.GetAllCards().Where(card => Filter.Applies(card, game, game.GetPlayer(card.Owner))))
            {
                if (game.BattleZone.GetCreatures(card.Owner).Any(x => x.Subtypes.Contains(Subtype.AngelCommand)))
                {
                    card.Power += _power;
                }
            }
        }

        public override string ToString()
        {
            return $"While you have at least 1 Angel Command in the battle zone, {Filter} gets +{_power} power.";
        }
    }
}
