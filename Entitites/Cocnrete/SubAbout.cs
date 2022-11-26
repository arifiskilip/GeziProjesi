using Core.Entities;

namespace Entities.Cocnrete
{
    public class SubAbout : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
