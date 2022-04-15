using Engine;
using Engine.Abilities;
using System.Collections.Generic;
using System.Linq;

namespace Cards.Cards.DM07
{
    class ArmoredTransportGaliacruse : Creature
    {
        public ArmoredTransportGaliacruse() : base("Armored Transport Galiacruse", 6, 5000, Engine.Subtype.Armorloid, Engine.Civilization.Fire)
        {
            AddTapAbility(new ArmoredTransportGaliacruseEffect());
        }
    }

    class ArmoredTransportGaliacruseEffect : OneShotEffects.OneShotAreaOfEffect
    {
        public ArmoredTransportGaliacruseEffect() : base()
        {
        }

        public override object Apply(IGame game, IAbility source)
        {
            
            game.AddContinuousEffects(source, new ContinuousEffects.ThisCreatureGetsAbilityUntilTheEndOfTheTurnEffect(
                new StaticAbilities.ThisCreatureCanAttackUntappedCreaturesAbility(),
                GetAffectedCards(game, source).ToArray()));
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

        protected override IEnumerable<ICard> GetAffectedCards(IGame game, IAbility source)
        {
            return game.BattleZone.GetCreatures(source.Controller, Engine.Civilization.Fire);
        }
    }
}
