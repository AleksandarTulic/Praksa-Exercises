namespace StudentService.Settings{
    public class PostgreSQL{
        public string UserId {get; init;}
        public string Password {get; init;}
        public string Server{get; init;} //host
        public int Port {get; init;}
        public string Database {get; init;}

        public string ConnectionString => $"User ID={UserId};Password={Password};Server={Server};Port={Port};Database={Database}; Integrated Security=true;Pooling=true;";
    }
}