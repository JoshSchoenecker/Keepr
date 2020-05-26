// They only require a name and a description and will then have a list of posts that are saved within the vault. Think about how you will handle this relationship.

namespace Keepr.Models
{
    public class Vault
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public string UserId { get; set; }
    }
}