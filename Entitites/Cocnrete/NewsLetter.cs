using Core.Entities;

namespace Entities.Cocnrete
{
    public class NewsLetter : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
    }
}
