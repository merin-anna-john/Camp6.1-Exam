﻿using System;
using System.Collections.Generic;

namespace AssetManagementSystem_WebApi_MidExam.Models;

public partial class AssetDefinition
{
    public int AdId { get; set; }

    public string AdName { get; set; } = null!;

    public int? AdTypeId { get; set; }

    public string? AdClass { get; set; }

    public virtual AssetType? AdType { get; set; }

    public virtual ICollection<AssetMaster> AssetMasters { get; set; } = new List<AssetMaster>();

    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();
}
