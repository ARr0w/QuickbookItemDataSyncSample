using System.Text.Json.Serialization;

namespace QuickbookItemDataSyncSample.Models.QbResponseModels
{
    public class ItemsModel
    {
        [JsonPropertyName("item")]
        public List<ItemModel> Items { get; set; }
    }

    public class ItemModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public string FullyQualifiedName { get; set; }
        public bool Taxable { get; set; }
        public decimal UnitPrice { get; set; }
        public string Type { get; set; }
        public IncomeAccountRef? IncomeAccountRef { get; set; }
        public decimal PurchaseCost { get; set; }
        public bool TrackQtyOnHand { get; set; }
        public string? domain { get; set; }
        public bool sparse { get; set; }
        public string? Id { get; set; }
        public string? SyncToken { get; set; }
        public MetaData? MetaData { get; set; }
        public string? PurchaseDesc { get; set; }
        public ExpenseAccountRef? ExpenseAccountRef { get; set; }
        public AssetAccountRef? AssetAccountRef { get; set; }
        public int? QtyOnHand { get; set; }
        public DateTime? InvStartDate { get; set; }
    }

    public class IncomeAccountRef
    {
        public string value { get; set; }
        public string name { get; set; }
    }

    public class ExpenseAccountRef
    {
        public string value { get; set; }
        public string name { get; set; }
    }

    public class AssetAccountRef
    {
        public string value { get; set; }
        public string name { get; set; }
    }

    public class MetaData
    {
        public DateTime CreateTime { get; set; }
        public DateTime LastUpdatedTime { get; set; }
    }

    public class ItemResponseRootModel
    {
        public ItemsModel QueryResponse { get; set; }
    }
}
