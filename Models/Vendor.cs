using System;
using System.Collections.Generic;

namespace AssetManagementSystem_WebApi_MidExam.Models;

public partial class Vendor
{
    public int VdId { get; set; }

    public string VdName { get; set; } = null!;

    public string? VdType { get; set; }

    public int? VdAtypeId { get; set; }

    public DateOnly VdFrom { get; set; }

    public DateOnly VdTo { get; set; }

    public string? VdAddr { get; set; }

    public virtual ICollection<AssetMaster> AssetMasters { get; set; } = new List<AssetMaster>();

    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();

    public virtual AssetType? VdAtype { get; set; }
}
