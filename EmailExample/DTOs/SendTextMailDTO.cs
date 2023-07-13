namespace EmailExample.DTOs{
    public record SendTextMailDTO{
        public string Sender {get; init;} = "";
        public string Receiver {get; init;} = "";
        public string Content {get; init;} = "";
    }
}