namespace DbExploration.Models{
    public class DriverMedia{
        public int Id {get; set;}
        public byte[] Media {get; set;}
        public string Caption {get; set;}

        public Guid DriverId {get; set;}
        public Driver Driver {get; set;}
    }
}