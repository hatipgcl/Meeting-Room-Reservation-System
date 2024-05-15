using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entity;

public partial class Equipment : IEntity
{
    public int EquipmentId { get; set; }

    public string EquipmentName { get; set; } = null!;

    public int InsertUserId { get; set; }

    public DateTime InsertDate { get; set; }

    public int? UpdateUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<MeetingEquipment> MeetingEquipments { get; set; } = new List<MeetingEquipment>();

    public virtual ICollection<RoomToEquipment> RoomToEquipments { get; set; } = new List<RoomToEquipment>();
}
