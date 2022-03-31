using Common;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM08
{
    class Dracobarrier : Spell
    {
        public Dracobarrier() : base("Dracobarrier", 3, Civilization.Light)
        {
            ShieldTrigger = true;
            AddSpellAbilities(new DracobarrierEffect());
        }
    }

    class DracobarrierEffect : OneShotEffect
    {
        public override object Apply(IGame game, IAbility source)
        {
            var tapped = new OneShotEffects.ChooseOneOfYourOpponentsCreaturesInTheBattleZoneAndTapItEffect().Apply(game, source);
            if (tapped.Any(x => x.IsDragon))
            {
                source.GetController(game).PutFromTopOfDeckIntoShieldZone(1, game);
            }
            return tapped;
        }

        public override IOneShotEffect Copy()
        {
            return new DracobarrierEffect();
        }

        public override string ToString()
        {
            return "Choose one of your opponent's creatures in the battle zone and tap it. If it has Dragon in its race, add the top card of your deck to your shields face down.";
        }
    }
}
