namespace MemoryBook.Main.Models
{
    public class NodeModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public byte[]? ImageByte { get; set; }
        public byte[]? TextData { get; set; }
        public string? Type { get; set; }
        public Guid GroupId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedDate { get; set; }
        public List<NodeModel> Connections { get; set; } = new List<NodeModel>();
    }
}
