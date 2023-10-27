using Static.Models.Abstracts.Interfaces;

namespace Static.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}