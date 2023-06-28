using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM07
{
    class ArmoredTransportGaliacruse : Creature
    {
        public ArmoredTransportGaliacruse() : base("Armored Transport Galiacruse", 6, 5000, Race.Armorloid, Civilization.Fire)
        {
            AddTapAbility(new ArmoredTransportGaliacruseEffect());
        }
    }

    class ArmoredTransportGaliacruseEffect : OneShotEffects.OneShotAreaOfEffect
    {
        public ArmoredTransportGaliacruseEffect() : base()
        {
        }

        public override void Apply()
        {
            Game.AddContinuousEffects(Ability, new ContinuousEffects.ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(
                new StaticAbilities.ThisCreatureCanAttackUntappedCreaturesAbility(),
                GetAffectedCards(Ability).ToArray()));
        }

        public override IOneShotEffect Copy()
        {
            return new ArmoredTransportGaliacruseEffect();
        }

        public override string ToString()
        {
            return "Each of your fire creatures gets \"This creature can attack untapped creatures\" until the end of the turn.";
        }

        protected override IEnumerable<ICard> GetAffectedCards(IAbility source)
        {
            return Game.BattleZone.GetCreatures(Applier, Civilization.Fire);
        }
    }
}
