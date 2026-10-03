using Template.Domain.Common.Abstrations;

namespace Template.Domain.Model;

public partial class BaseModel : IEntity
{
    public int Id { get; set; }
    public int CreateUserId { get; set; }
    public DateTime CreateUserDt { get; set; } = DateTime.Now;
    public int UpdateUserId { get; set; }
    public DateTime UpdateUserDt { get; set; } = DateTime.Now;
}
