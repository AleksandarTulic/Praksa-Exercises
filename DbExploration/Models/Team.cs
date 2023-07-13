namespace DbExploration.Models{
    public class Team : BaseEntity{
        public Team(){
            Drivers = new HashSet<Driver>();
        }

        public string Name {get; set;} = "";
        public string Year {get; set;} = "";

        public virtual ICollection<Driver> Drivers { get; set; }
    }
}