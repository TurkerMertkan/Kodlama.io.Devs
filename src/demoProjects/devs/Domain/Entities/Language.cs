using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Language : Entity
    {
        public string Name { get; set; }
        public Language()
        {
        }

        public Language(int id, string name) : this()
        {
            Name = name;
            Id = id;
        }
    }
}
