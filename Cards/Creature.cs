using Cards.ContinuousEffects;
using Cards.TriggeredAbilities;
using Engine;
using Engine.Abilities;
using System.Collections.Generic;

namespace Cards
{
    class Creature : Engine.Creature
    {
        protected Creature(string name, int manaCost, int power, Race race, params Civilization[] civilizations) : base(
            tapped: false, [.. civilizations], manaCost, summoningSickness: true, power, name, [race])
        {
        }

        protected Creature(string name, int manaCost, int power, List<Race> races, params Civilization[] civilizations)
            : base(tapped: false, [.. civilizations], manaCost, summoningSickness: true, power, name, races)
        {
        }

        protected void AddPowerAttackerAbility(int power)
        {
            AddStaticAbilities(new PowerAttackerEffect(power));
        }

        #region Triggered abilities
        protected void AddTriggeredAbility(ITriggeredAbility ability)
        {
            AddAbilities(ability);
        }

        protected void AddWhenYouPutThisCreatureIntoTheBattleZoneAbility(IOneShotEffect effect)
        {
            AddTriggeredAbility(new WhenYouPutThisCreatureIntoTheBattleZoneAbility(effect));
        }

        protected void AddAtTheEndOfYourTurnAbility(IOneShotEffect effect)
        {
            AddTriggeredAbility(new AtTheEndOfYourTurnAbility(effect));
        }

        protected void AddWheneverThisCreatureAttacksAbility(IOneShotEffect effect)
        {
            AddTriggeredAbility(new WheneverThisCreatureAttacksAbility(effect));
        }

        protected void AddWhenThisCreatureIsDestroyedAbility(IOneShotEffect effect)
        {
            AddTriggeredAbility(new WhenThisCreatureIsDestroyedAbility(effect));
        }
        #endregion Triggered abilities

        protected void AddTapAbility(IOneShotEffect effect)
        {
            AddAbilities(new TapAbility(effect));
        }
    }
}
