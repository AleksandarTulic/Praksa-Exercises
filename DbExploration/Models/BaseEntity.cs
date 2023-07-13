namespace DbExploration.Models{
    public abstract class BaseEntity{
        public Guid Id {get; set;} = Guid.NewGuid();
        public DateTime UpdateDate {get; set;} = DateTime.UtcNow;
        public string UpdateBy {get; set;} = "";
        public string AddedBy {get; set;} = "";
        public DateTime AddedDate {get; set;} = DateTime.UtcNow;
        public int Status {get; set;} = 1;
    }
}