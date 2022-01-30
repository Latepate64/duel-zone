using Cards.CardFilters;
using Cards.StaticAbilities;
using DuelMastersModels;
using DuelMastersModels.Abilities;
using DuelMastersModels.ContinuousEffects;
using DuelMastersModels.Durations;

namespace Cards.Cards.DM10
{
    public class PalaOlesisMorningGuardian : Creature
    {
        public PalaOlesisMorningGuardian() : base("Pala Olesis, Morning Guardian", 3, Civilization.Light, 2500, Subtype.Guardian)
        {
            Abilities.Add(new BlockerAbility());

            // During your opponent's turn, each of your other creatures gets +2000 power.
            var ability = new StaticAbility();
            ability.ContinuousEffects.Add(new PowerModifyingEffect(new PalaOlesisFilter(), 2000, new Indefinite()));
            Abilities.Add(ability);

            Abilities.Add(new CannotAttackPlayersAbility());
        }
    }
}
