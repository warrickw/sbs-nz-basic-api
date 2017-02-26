using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SbsApiV2.Models.AccountGet
{
    public class AccountGetRequest
    {
        public AccountGetRequest()
        {

        }

        /// <summary>
        /// Create a new account get resuest parameters object with some basic query parameters
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="chunkNumber"></param>
        public AccountGetRequest(DateTime from, DateTime to, int chunkNumber, List<AllChunkParameter> allChunkParameters)
        {
            // Change the from and to date from utc into nzst since the bank api expects this
            FromDate = TimeZoneInfo.ConvertTime(from, TimeZoneInfo.FindSystemTimeZoneById("New Zealand Standard Time")).ToString("yyyy-MM-dd");
            ToDate = TimeZoneInfo.ConvertTime(to, TimeZoneInfo.FindSystemTimeZoneById("New Zealand Standard Time")).ToString("yyyy-MM-dd");
            ChunkNumberRequested = chunkNumber;
            AllChunkParameters = allChunkParameters;
        }


        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Filters { get; set; }
        public string SearchFields { get; set; }
        public string SearchValue { get; set; }
        public int ChunkSize { get; set; } = 90;
        public int ChunkNumberRequested { get; set; }
        public int PayeeId { get; set; } = 0;
        public string TransactionType { get; set; } = "All Transactions";
        public List<AllChunkParameter> AllChunkParameters { get; set; } = new List<AllChunkParameter>();
        public readonly string DocumentType = "TransactionSearchRequest";
    }
}