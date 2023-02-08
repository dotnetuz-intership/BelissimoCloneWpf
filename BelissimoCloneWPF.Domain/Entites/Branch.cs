using BelissimoCloneWPF.Domain.Commons;

namespace BelissimoCloneWPF.Domain.Entites.Branches
{
    public sealed class Branch : Auditable
    {
        public string Operators { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
