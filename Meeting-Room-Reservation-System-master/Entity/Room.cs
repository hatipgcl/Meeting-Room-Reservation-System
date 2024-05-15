using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entity;

public partial class Room : IEntity
{
    public int RoomId { get; set; }

    public string RoomName { get; set; } = null!;

    public short Capasity { get; set; }

    public int LocationId { get; set; }

    public int InsertUserId { get; set; }

    public DateTime InsertDate { get; set; }

    public int? UpdateUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<RoomToEquipment> RoomToEquipments { get; set; } = new List<RoomToEquipment>();
}
