using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entity;

public partial class Location : IEntity
{
    public int LocationId { get; set; }

    public string LocationName { get; set; } = null!;

    public short RoomCount { get; set; }

    public string Adress { get; set; } = null!;

    public int InsertUserId { get; set; }

    public DateTime InsertDate { get; set; }

    public int? UpdateUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<LocationToRoom> LocationToRooms { get; set; } = new List<LocationToRoom>();
}
