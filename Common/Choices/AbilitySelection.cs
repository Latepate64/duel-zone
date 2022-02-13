using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Choices
{
    public class AbilitySelection : GuidSelection
    {
        public List<AbilityText> Abilities { get; set; }

        public AbilitySelection()
        {
        }

        public AbilitySelection(Guid player, IEnumerable<AbilityText> abilities, int minimumSelection, int maximumSelection) : base(player, abilities.Select(x => x.Id), minimumSelection, maximumSelection)
        {
            Abilities = abilities.ToList();
        }

        public override string ToString()
        {
            return "Choose an ability to resolve.";
        }
    }

    public class AbilityText
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public AbilityText()
        {
        }

        public AbilityText(Guid id, string text)
        {
            Id = id;
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
