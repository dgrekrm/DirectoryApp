using Npgsql;

var cs = @"Server=127.0.0.1;Port=5432;Database=testdatabase;User Id=postgres;Password=Qasx7865";

using var con = new NpgsqlConnection(cs);
con.Open();

var sql = "SELECT NOW()";

using var cmd = new NpgsqlCommand(sql, con);

var date = cmd.ExecuteScalar().ToString();
Console.WriteLine($"PostgreSQL version: {date}");

Console.ReadLine();