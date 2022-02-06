using Cards.CardFilters;
using Cards.StaticAbilities;
using Engine;
using Engine.Abilities;
using Engine.ContinuousEffects;
using Engine.Durations;
using System.Linq;

namespace Cards.OneShotEffects
{
    class AuraBlastEffect : OneShotEffect
    {
        public override void Apply(Game game, Ability source)
        {
            game.ContinuousEffects.Add(new AbilityGrantingEffect(new TargetsFilter(game.BattleZone.GetCreatures(source.Owner).Select(x => x.Id)), new UntilTheEndOfTheTurn(), new PowerAttackerAbility(2000)));
        }

        public override OneShotEffect Copy()
        {
            return new AuraBlastEffect();
        }

        public override string ToString()
        {
            return "Each of your creatures in the battle zone gets \"power attacker +2000\" until the end of the turn. (While attacking, a creature that has \"power attacker +2000\" gets + 2000 power.)";
        }
    }
}
