using Engine;
using Engine.ContinuousEffects;
using System.Linq;

namespace Cards.Cards.DM01
{
    class Tropico : Creature
    {
        public Tropico() : base("Tropico", 5, 3000, Common.Subtype.CyberLord, Common.Civilization.Water)
        {
            AddStaticAbilities(new TropicoEffect());
        }
    }

    class TropicoEffect : ContinuousEffect, IUnblockableEffect
    {
        public TropicoEffect() : base(new TargetFilter(), new Durations.Indefinite())
        {
        }

        public bool Applies(ICard blocker, IGame game)
        {
            var ability = game.GetAbility(SourceAbility);
            return game.BattleZone.GetCreatures(ability.Controller).Count(x => x.Id != ability.Source) >= 2;
        }

        public override IContinuousEffect Copy()
        {
            return new TropicoEffect();
        }

        public override string ToString()
        {
            return "This creature can't be blocked while you have at least 2 other creatures in the battle zone.";
        }
    }
}
