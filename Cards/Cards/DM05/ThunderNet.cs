using Common;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM05
{
    class ThunderNet : Spell
    {
        public ThunderNet() : base("Thunder Net", 2, Civilization.Water)
        {
            AddSpellAbilities(new ThunderNetEffect());
        }
    }

    class ThunderNetEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var amount = game.BattleZone.GetCreatures(source.Owner).Where(x => x.Civilizations.Contains(Civilization.Water)).Count();
            return new OneShotEffects.ChooseUpToOfYourOpponentsCreaturesInTheBattleZoneAndTapThemEffect(amount).Apply(game, source);
        }

        public override IOneShotEffect Copy()
        {
            return new ThunderNetEffect();
        }

        public override string ToString()
        {
            return "For each water creature you have in the battle zone, you may choose one of your opponent's creatures in the battle zone and tap it.";
        }
    }
}
