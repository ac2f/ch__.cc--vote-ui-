using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coinhunters_cc_vote_bot_ui
{
    partial class Token
    {
        public string _id { get; set; }
        public Dictionary<string, string> price_variation { get; set; }
        public bool is_prelaunch { get; set; }
        public bool created_by_admin { get; set; }
        public int today_up_votes { get; set; }
        public int today_scam_votes { get; set; }
        public bool listed { get; set; }
        public string contract { get; set; }
        public string chain{ get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string description { get; set; }
        public string website { get; set; }
        public string telegram { get; set; }
        public string twitter { get; set; }
        public string discord { get; set; }
        public long launch_date { get; set; }
        public string logo { get; set; }
        public string owner { get; set; }
        public string totalSupply { get; set; }
        public string decimals { get; set; }
        public int scam_votes { get; set; }
        public int up_votes { get; set; }
        public string url { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public int __v { get; set; }
        public int rank { get; set; }
        public int votes_next_rank { get; set; }
        public bool daily_winner { get; set; }
    }
}
