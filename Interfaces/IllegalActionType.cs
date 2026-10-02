namespace Interfaces;

public enum IllegalActionType
{
    Unknown,
    UnexpectedType,
    HandDoesNotContainCard,
    UseCardTappedManaForPayment,
    UseCardPaymentForManaCost,
    UseCardPaymentForCivilizations,
    AttackingCreatureIsNull,
    AttackingCreatureIsTapped,
    AttackingCreatureHasSummoningSickness,
    AttackedCreatureAndAttackedPlayerAreNull,
    AttackedCreatureAndAttackedPlayerAreNotNull,
    ChosenCardIsNull,
}