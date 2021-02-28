using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PaymentApp.Common.Message
{
    public static class Message
    {
        private static readonly IConfiguration config = new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

        public static string AccountNotExist => config["App:AccountNotExist"];
        public static string InvalidUserNamePassword => config["App:InvalidUserNamePassword"];
    }
}
