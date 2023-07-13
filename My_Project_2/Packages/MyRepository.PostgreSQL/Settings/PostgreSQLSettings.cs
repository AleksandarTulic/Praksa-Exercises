namespace MyRepository.PostgreSQL.Settings{
    public class PostgreSQLSettings{
        public required string UserId {get; init;}
        public required string Password {get; init;}
        public required string Server{get; init;} //host
        public int Port {get; init;}
        public required string Database {get; init;}

        public string ConnectionString => $"User ID={UserId};Password={Password};Server={Server};Port={Port};Database={Database}; Integrated Security=true;Pooling=true;";
    }
}