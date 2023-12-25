using Shaker.Domain.Core;

namespace Shaker.Domain.Entities;

public class Shakers : EntityBase
{
    public string ShakerName { get; set; }
    public string BuildingName { get; set; }
    public int FloorCount { get; set; }
    public string RoomName { get; set; }
    public int ShakerOptionsId { get; set; }
    public bool Status { get; set; }
}
