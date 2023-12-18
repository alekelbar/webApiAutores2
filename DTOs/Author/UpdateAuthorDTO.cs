using webApi.Entities;

namespace webApi.DTO
{
    public class UpdateAuthorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}