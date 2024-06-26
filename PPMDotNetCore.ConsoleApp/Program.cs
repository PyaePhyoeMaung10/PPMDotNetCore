﻿// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PPMDotNetCore.ConsoleApp.AdoDotNetExample;
using PPMDotNetCore.ConsoleApp.DapperExamples;
using PPMDotNetCore.ConsoleApp.EFCoreExamples;
using PPMDotNetCore.ConsoleApp.Services;
using System.Data;
using System.Data.SqlClient;
//Console.WriteLine("Hello, World!");

//package for => nuget
/*SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
stringBuilder.DataSource = "Pyae02"; //server name
stringBuilder.InitialCatalog = "PPMDotNetCore"; //database name
stringBuilder.UserID = "sa"; //user name
stringBuilder.Password = "sasa@123"; //psassword
SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);


connection.Open();
Console.WriteLine("Connection open.");

string query = "select * from Tbl_blog";
SqlCommand cmd = new SqlCommand(query, connection);
SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
DataTable dt = new DataTable();
sqlDataAdapter.Fill(dt);


connection.Close();
Console.WriteLine("Connection close.");

foreach (DataRow dr in dt.Rows)
{
    Console.WriteLine("Blog Id => " + dr["BlogId"]);
    Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
    Console.WriteLine("Blog Author => " + dr["BlogAuthor"]);
    Console.WriteLine("Blog Content => " + dr["BogContent"]);
    Console.WriteLine("--------------------------");
}
Console.ReadKey();*/
//AdoDotNetTuto adoDotNetTuto = new AdoDotNetTuto();
/*adoDotNetTuto.Read();
adoDotNetTuto.Create("title", "author", "content");
adoDotNetTuto.Update(3,"testing","author","content");
adoDotNetTuto.Delete(3);*/
//adoDotNetTuto.Edit(2);
//adoDotNetTuto.Edit(1002);
//DapperExample dapper = new DapperExample();
//dapper.Run();
//EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Run();
var connectionString = ConnectionString.SqlConnectionStringBuilder.ConnectionString;
var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
var serverProvider = new ServiceCollection()
    .AddScoped(n => new AdoDotNetTuto(sqlConnectionStringBuilder))
    .AddScoped(n => new DapperExample(sqlConnectionStringBuilder))
    .AddDbContext<AddDbContext>(opt =>
    {
        opt.UseSqlServer(connectionString);
    })
    .AddScoped<EFCoreExample>()
    .BuildServiceProvider();
var adoDotNetExample = serverProvider.GetRequiredService<AdoDotNetTuto>();
adoDotNetExample.Read();

var dapperExample = serverProvider.GetRequiredService<DapperExample>();
dapperExample.Run();
//AddDbContext db =  serverProvider.GetRequiredService<AddDbContext>();
Console.ReadLine();