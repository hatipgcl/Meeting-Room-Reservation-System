using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entity;

public partial class MeetingEquipment : IEntity
{
    public int MeetingEquipmentId { get; set; }

    public int EquipmentId { get; set; }

    public int MeetingRequestId { get; set; }

    public int InsertUserId { get; set; }

    public DateTime InsertDate { get; set; }

    public int? UpdateUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public bool Status { get; set; }

    public virtual Equipment Equipment { get; set; } = null!;

    public virtual MeetingRequest MeetingRequest { get; set; } = null!;
}
