using Common;
using Engine;
using Engine.Abilities;
using System.Linq;

namespace Cards.Cards.DM07
{
    class ArmoredTransportGaliacruse : Creature
    {
        public ArmoredTransportGaliacruse() : base("Armored Transport Galiacruse", 6, 5000, Subtype.Armorloid, Civilization.Fire)
        {
            AddAbilities(new TapAbility(new ArmoredTransportGaliacruseEffect()));
        }
    }

    class ArmoredTransportGaliacruseEffect : OneShotEffects.OneShotAreaOfEffect
    {
        public ArmoredTransportGaliacruseEffect() : base(new CardFilters.OwnersBattleZoneCivilizationCreatureFilter(Civilization.Fire))
        {
        }

        public override object Apply(IGame game, IAbility source)
        {
            game.AddContinuousEffects(source, new ContinuousEffects.ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(
                new CardFilters.TargetsFilter(GetAffectedCards(game, source).ToArray()),
                new StaticAbilities.ThisCreatureCanAttackUntappedCreaturesAbility()));
            return null;
        }

        public override IOneShotEffect Copy()
        {
            return new ArmoredTransportGaliacruseEffect();
        }

        public override string ToString()
        {
            return "Each of your fire creatures gets \"This creature can attack untapped creatures\" until the end of the turn.";
        }
    }
}
