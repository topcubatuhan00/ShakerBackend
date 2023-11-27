namespace Shaker.Domain.Core;

public class EntityBase
{
    public virtual int Id { get; set; }
    public string? CreatorName { get; set; } = "Admin";
    public DateTime? CreatedDate { get; set; } = DateTime.Now;
    public string? UpdaterName { get; set; } = null;
    public DateTime? UpdatedDate { get; set; } = null;
    public string? DeleterName { get; set; } = null;
    public DateTime? DeletedDate { get; set; } = null;

}
