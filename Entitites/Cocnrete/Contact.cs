using Core.Entities;

namespace Entities.Cocnrete
{
    public class Contact : IEntity
    {
        public int Id { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public string MapLocation { get; set; }
        public bool Status { get; set; }
    }
}
