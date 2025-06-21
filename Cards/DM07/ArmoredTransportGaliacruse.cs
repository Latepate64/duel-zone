using OneShotEffects;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using ContinuousEffects;

namespace Cards.DM07
{
    class ArmoredTransportGaliacruse : Creature
    {
        public ArmoredTransportGaliacruse() : base("Armored Transport Galiacruse", 6, 5000, Race.Armorloid, Civilization.Fire)
        {
            AddAbilities(new TapAbility(new ArmoredTransportGaliacruseEffect()));
        }
    }

    class ArmoredTransportGaliacruseEffect : OneShotAreaOfEffect
    {
        public ArmoredTransportGaliacruseEffect() : base()
        {
        }

        public override void Apply(IGame game)
        {
            game.AddContinuousEffects(Ability, new ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(
                new StaticAbility(new ThisCreatureCanAttackUntappedCreaturesEffect()),
                [.. GetAffectedCards(game, Ability)]));
        }

        public override IOneShotEffect Copy()
        {
            return new ArmoredTransportGaliacruseEffect();
        }

        public override string ToString()
        {
            return "Each of your fire creatures gets \"This creature can attack untapped creatures\" until the end of the turn.";
        }

        protected override IEnumerable<Card> GetAffectedCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(Ability.Controller.Id, Civilization.Fire);
        }
    }
}
