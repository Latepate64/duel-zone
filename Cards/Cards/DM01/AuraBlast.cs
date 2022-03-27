using Cards.OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM01
{
    class AuraBlast : Spell
    {
        public AuraBlast() : base("Aura Blast", 4, Common.Civilization.Nature)
        {
            AddSpellAbilities(new AuraBlastEffect());
        }
    }

    class AuraBlastEffect : OneShotAreaOfEffect
    {
        public AuraBlastEffect() : base(new CardFilters.OwnersBattleZoneCreatureFilter())
        {
        }

        public override object Apply(IGame game, IAbility source)
        {
            game.AddContinuousEffects(source, new ContinuousEffects.ThisCreatureGetsPowerAttackerUntilTheEndOfTheTurnEffect(GetAffectedCards(game, source).ToArray()));
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new AuraBlastEffect();
        }

        public override string ToString()
        {
            return "Each of your creatures in the battle zone gets \"power attacker +2000\" until the end of the turn.";
        }
    }
}
