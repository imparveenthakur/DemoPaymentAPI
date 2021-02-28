using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PaymentApp.Common.StaticConstants
{
    public static class Constants
    {
        #region Field Initilizations
        private static readonly IConfiguration config = new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        #endregion

        #region Compile time constants

        public const int DefaultPageSize = 30;
        public const int DefaultPageNo = 1;
        public const int MaxPageSize = 500;
        public const int CommentMaxLength = 300;
        public const int TextMaxLenght = 5000;

        #endregion

        #region Run Time Constants
        public static string LogFilePath => config["App:LogFilePath"];
        public static string ConnectionString => config["App:ConnectionString"];
        public static string TokenSecretKey => config["App:TokenSecretKey"];
        public static string TokenIssuer => config["App:TokenIssuer"];
        public static string TokenAudience => config["App:TokenAudience"];
        public static string TokenExpiryDays => config["App:TokenExpiryDays"];
        #endregion
    }
}

