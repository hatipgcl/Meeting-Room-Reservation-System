using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entity;

public partial class LocationToRoom : IEntity
{
    public int LocationToRoomsId { get; set; }

    public int LocationId { get; set; }

    public int RoomId { get; set; }

    public int InsertUserId { get; set; }

    public DateTime InsertDate { get; set; }

    public int? UpdateUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public bool Status { get; set; }

    public virtual Location Location { get; set; } = null!;
}
