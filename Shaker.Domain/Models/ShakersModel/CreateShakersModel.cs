﻿namespace Shaker.Domain.Models.ShakersModel;

public class CreateShakersModel
{
    public string ShakerName { get; set; }
    public string BuildingName { get; set; }
    public int FloorCount { get; set; }
    public string RoomName { get; set; }
    public bool Status { get; set; }
    public string CreatorName { get; set; }
}
