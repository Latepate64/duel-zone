using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM08
{
    class LaserWhip : Spell
    {
        public LaserWhip() : base("Laser Whip", 4, Civilization.Light)
        {
            AddSpellAbilities(new LaserWhipEffect());
        }
    }

    class LaserWhipEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            (new IOneShotEffect[] { new OneShotEffects.ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect(), new OneShotEffects.ChooseOneOfYourCreaturesInTheBattleZoneItCannotBeBlockedThisTurnEffect() }).ToList().ForEach(x => x.Apply(game, source));
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new LaserWhipEffect();
        }

        public override string ToString()
        {
            return "Choose one of your opponent's creatures in the battle zone and tap it. Then you may choose one of your creatures in the battle zone. If you do, it can't be blocked this turn.";
        }
    }
}
