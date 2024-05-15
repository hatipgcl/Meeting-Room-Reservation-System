using Core.Entities;
using System;
using System.Collections.Generic;

namespace Entity;

public partial class MeetingRequest : IEntity
{
    public int MeetingRequestId { get; set; }

    public int RoomId { get; set; }

    public DateTime MeetingDate { get; set; }

    public string StartTime { get; set; } = null!;

    public string EndTime { get; set; } = null!;

    public int AttendeeCount { get; set; }

    public int InsertUserId { get; set; }

    public DateTime InsertDate { get; set; }

    public int? UpdateUserId { get; set; }

    public DateTime? UpdateDate { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<MeetingEquipment> MeetingEquipments { get; set; } = new List<MeetingEquipment>();
}
