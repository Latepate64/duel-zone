using DuelMastersModels.Abilities;
using DuelMastersModels.Cards;
using DuelMastersModels.Effects.ContinuousEffects;
using DuelMastersModels.Choices;
using System.Collections.Generic;

namespace DuelMastersModels.Managers
{
    public interface IAbilityManager
    {
        bool IsAbilityBeingResolved { get; }
        bool IsAbilityBeingResolvedSpellAbility { get; }

        PlayerActionWithEndInformation ContinueResolution(IDuel duel);
        ICollection<IContinuousEffect> GetContinuousEffectsGeneratedByCard(ICard card, IPlayer player);
        int GetSpellAbilityCount(ISpell spell);
        void RemovePendingAbility(INonStaticAbility ability);
        void SetAbilityBeingResolved(INonStaticAbility ability);
        void StartResolvingSpellAbility(ISpell spell);
        void TriggerWheneverAnotherCreatureIsPutIntoTheBattleZoneAbilities(IEnumerable<IBattleZoneCreature> creatures);
        void TriggerWheneverAPlayerCastsASpellAbilities(IEnumerable<IBattleZoneCreature> creatures);
        void TriggerWhenYouPutThisCreatureIntoTheBattleZoneAbilities(IBattleZoneCreature creature);
        SelectAbilityToResolve TryGetSelectAbilityToResolve(IPlayer player);
    }
}