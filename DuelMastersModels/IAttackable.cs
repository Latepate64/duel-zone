using System;

namespace DuelMastersModels
{
    public interface IAttackable : IIdentifiable
    {
    }

    public interface IIdentifiable
    {
        Guid Id { get; set; }
    }
}
