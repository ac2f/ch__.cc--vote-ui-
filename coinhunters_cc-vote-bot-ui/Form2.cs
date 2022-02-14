using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coinhunters_cc_vote_bot_ui
{
    public partial class Form2 : Form
    {
        public int voted = 0;
        HttpClient client = new HttpClient();
        Dictionary<string, string> postData = new Dictionary<string, string>()
        {
            { "h-captcha-response", "P0_eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJwYXNza2V5IjoiRGNtenRaZjR0Qmp4cGlKR3Z5T2w0bnd2b1hSVkIxVzByd2YxVGZRaDdwQ1BVOUxhY0VGMGZIYVdCSndjcVdValFIeW43REFQV3p5TXNPYk91cHpvRmZPaklBZXFSRW5FRzFmdWo4ZVNRcU5sUXhhREVEL2Z5WnFUZGU4TnBNdHJqaHZUcDAxTi9sczllMUJQYmp1SWpNSUJNYmdVUytpdUZWVmFYUWpUZTFQaWV0L3JJUmJpeU1xdkh1UXZpUUJ2dkZiRGpBenBNdHpmUkZWL3gvZkE4K0RidTJseWVvb2xHL3RRY2tNZVVMTHpPa2tlUlc3bG1VWHJsVlQxRjluc3BZQnY2bzQxSUQvQUsxOXUxNklHWVJjYU9Kd3BlSVNBVGlKYWpiRlQ3cWZKaldlV3F1aXZlOFlhaFBiamhGdU5aWUxXbW9FZ2hvVHJYSHpJTGlNOXdUalFLTXhaekk3ZnRLd0Fic1ZGZ2JvKzBuTFlyM0lXMlU3QUFEWG5kbzF3ajJBZnhHVmZoTWNlUWZ6QmpYUGZvMGJHcHhKY1k1VzdTSVhmanhKYXZHUUxHZXdPQ2ZoRSs4SXAyZDVqdGNnOFFQSUxIclJ5TXpFR0d6VDNJTnJEczNCUk4vSjJXK3BFUGFsZ3FsTDVXNURLbGFYbHZLdGdFNUpuWHJoU2ZVMWZMVnhycFlvV0tlMkt2d3pvVGo5Q3l2aDl6N25NZVBCYVhjdUNPOVZHdHNqWlFldjVWSUVrTzZwanNoWUtOdUtWYU9DNE55SjRuOEExQmdCTzFpdWpRdDBwL3FhV1JZMnpiVHRJZUFqRFIyNTViUnFnakZxVCtIdlA5VW5YMWVFbWswQWdZWU8zSDVEWGVEUXZEblJnejRDeUtQR0RHN0oyakYzdTB5MnQ0QjZtY2l6UmZVSTdTUWhZRE96aUtqeVZ5MTF4dXBReVYwMHZzYjcxV0JKazVWMmpLN0loNWt4OXVsTTV0a2t1Q00wZVJHY2MwcTVMNWsvU1phQ01iVDRYYWNIOVAvRHRZY2hOTThqZEQvUWtJWkNLUGNvTVZZSk9aTTNLVmgyckxPOTdHd2pRa0h5b2NoaVZ2T1lyVHZzcDk1VndzZUpHcmwzRmsrSGZ5ZGdmVWg2amZnamlnWjd4NEh1STI4OE9UM01IMGpPN0dCR25wT0xYYmxadFpwT1h3RWNMOUZQU1R0YmVSQTEzM2FTOHo2VWFzVitXazUzSDJCaXBMbmhLNlRZR3pyelVrNVpUaXFhVjB2L3RPZ1NvUVUydVN0Zjk4U3dBSkpJbXp3N3UzSHpYQ0h0UXZiakEwTVZCNGRxOG8xYXVnTVhrNDVEUVZBSVRIY0dFcndxaXk2MlFNM3VJYzlDSHY5QWxNSXYxNm5saEMrS0s5SGh5MGZjRzVSRkdIVUgrWUptTnovY3NIUXNFcEdhMkhadGtzV09sUWFkckYreGhKVFYwU2s0R1ZIVS9ZN2hPZzJhQll4bVk5R1RFMEdpdHJ1OEtxM3d2VGE1R0tDMUJ0c01mZFRzS1ExZWgzOHFTeGFlWTRrZ05nVjRkL1VPNmwwb2pzcjl3SEpIN2VjbHR1YzlMQmRrRWJlajlFUUxkMEJtYUVFVEVtUTB4WnYvdmhNVEhDY0hSRlh2QWUrdHVuZTUwY2xNaCsyVmRhMUdaU3NTZEFRSENpYk9HUXhwY0J3bGE1ZkpJYlJVQmlNOWZHUUVBVTZyeEhSOFNYaHNTblJjSUkrN2wxdk5QQWFrY050eGdZVWFDb1NURW1rTWp5NDZPZGlPNHVEVCs0UUVUNWZrMnlNRWJ0dEdqMEJhNGVSWkoxS3ZMUmRxcmNSdzhIY0EyZzVCZlJ6VWNUVlh0ZFVuVXZoZm5iTzErSWptVjVyRmNGVmVhS2d5VXdTa1ZDUUdVbmZxbzE3YkZzZkxzTkxNVkdpWjJtMXZQcm9CSzRaTmpDWG1aWkd0K0RQRG0wMEc3cnFIUXZiVUhOcUh2N1FFVEtFUzJmY2FDeFpBUmpYbnBNQlVtWFE5QUlxMGNvUEo5OTRMYmFoMTQ0cW5lWVdQbnNMTGtzaENPY1BibVpaSWcyMzMzWVc5R1FVZm1NMXVTV2RtRFlrdGp2UjZjVi9vcUlvQ3l3OXVMZEhvSjFsL2crSGpMSmRBcU1CaVpYczlBYSt0SnU0ZFNLb2JoYlhIei9Pb0hmTVdNRnBIRU94OXk1Qm9WVUg3RDRLQlhsVjFEWEJRYTJwKzFaUitsdmZ4YlErMGkwMEoya21mVVhUeEZtWHE3cW01QlZPWGs2ZE5pTEt6R1VuT25JU2xrdDM1MGVXMllvV0NCV2Q5RkdNaW5heTUwUzZuNm1LWTU0R1VWT2JkWWlmTEpZQ2NBV095NE11TTRGbkcwNjdMUjdwdkJZMi93S1Nsc2gvWTViRFo1WjlwcE5pL20vSFQxSUsydUxMcDBlZ2pnNHEvdWZ5TE9ObVA1SWpIbXN6ZlNNR2dTSG9xQ1VSekVXbUNDRnhQdGcwN2Y1c1c4bWVaVjlac3BsbnA1ZDBUZmtmMWpsT0dtYzF2ZUtsd2t5c2plSmd1SytoekdHVlJOZHg5alZHRXh4RlgxTENBdlYwbEE1bkgrclBtQzJqTTZib2JxTVFubU1VRHNOYmhzazQ2bXk3WTA4R29adTM2WTNnMzdvam1ubU1zNTc3aFFBcFdZbmxTUml6MkhaYlhDNitiUmhvbnNibnJJMGpwTnUrNzVGWktHSml0dkQvL0NNNjk2NFI2Wmg4U0VoSC9ncmxIUFBiVDRNLzJUdUdFUng2M3k0ak1aV01vK1BKaHBZZXdNQVNPeU5MY2U3NmsyV3FqdERKSUd1RVRzRnNLKzUvQ0pLbEI5TFR3andYS0RxY3UvSHR5aWJSQkRBUTE3VWdDOFdlUkFScHB1TE1CMW82TGhBOFUwSVJCOEcyUkFKSjZKOFlZbmozb21uSWFyRklpSlhSMlVOS0swYmo3NU5MaXBQakdIK1c1YTZKYUJkcll2cmxOdElqdmVNRExvVmt1WjY2cjc0NTRHN0NTRjZUQjBLQ0xyRXRpMkt4TzlLTUlVVXVzNHZaR2xQRVhnb0xGOTFVaDNEbFBiRXVLNFc1am5uVS8vMG8xZWpVVzRqNWJ6eGpOVllCcERTNmR5TUxYQm5kV01CTm5VUVZXc2tENDB2VXlZWkJZcHQ0ZEtYWkEzMENudkhTNVN6NW1iVlFITVJZQjFsL0t0SkhrNGJMUXBNWlVLVzRWdGk2VDBTSlJFRVQ2bENWbmZMQ3hSeG5CZ1BkeXYwNHJlOXdmcDlGaDFaT1VjZHFGOFBPelhaZ1plNElOMlNKZ3MrTDg2M3FLU2RvZ2l0L0dWQVpLTTQrcG9tMHNaY1hMVlJzdFRyV1BEWGdYL0NybUZoNnRtL0g4aU5GNHRzTWhtSFdCUG01ZzdsSTdXRGtkYmY0dCtFUmM4eHBxbzc3SER6UTJUQVJ6NmRSQ2tiSjUrNWNvRWpLZzkwS1pMZklMR2JXaVdOK0Z4ekhxL1lxeUJWYzJVWjhOeTBoMEFwYm0ydktaMVFKNlR2STg4c3Z1SWY2dFlRQzArQUVUc0RaVjh4WTZDejBaQWFmQUZGbTY1QW5XR2lTZExRMTNab2VJQkJlQXY4dUtVdG8zK2hGVGl0VWwwWm1rZkMyWnVwTEdKaGo3QkVTaGJLNnllbkROK2t5dEJvS25GbFlzT1p4bE4vY0g0K0Y2Mld1ODAzUHBQUTRpcVZtUjF3Z3ZEdWl0UW5XMmszVlp1UEdaRlpjdm84b1pZdTB6aHNraXd4RmRacjFvKzAwdVkzcEgxREUvcUZieVN6MzZkcnJaeTZTdml0blo5Wkg4SWttVWUyWXk4NzVlM2JDOTRnVWFlMm1FaTZ1RDVIVU5oaUhGeGpEV3FIOFoyR3o2VEkrb3NUTnZBM0E0RmFYY2tkVGh0NnlRMmd1UGZRNi9jREYrZDJrRzRud0RtRk1obFlUVzl3R1pTclpzL0ZjdWMxc2hNS1dPSDFrN0E5WG5KOWhuQy9XMmYzQnlBQU40cjZDVUhHSmFOcWdTSHN2a2h3L1VYcmVPYm1VYSsvWXZlNlIyblNLQlNieVpZbFF6bCtXWjBYMTByeUxnaEtEbXZma2dlQmViNHJXT2p6UytHeWViZ1J0R1IzT0tlZUZrMWhqRHVtMytGYlRNcHMxbDlDeStkMDlBVnBFRkZMU2I1IiwiZXhwIjoxNjQzNDQyODk0LCJzaGFyZF9pZCI6ODIwNzg2MDg2LCJwZCI6MH0.M2MbcBC2fuRwuIg9WoFFDCE6y27H5WVeRkvBT4oKCKA" },
            { "tokenId", null }
        
        };
        Dictionary<string, string> tokens = new Dictionary<string, string>()
        {
            {"DOGE", "61f0acd09a1ea3bea3af5974"},
            {"TORHIUM", "61e859c9aeb5ed04735ccf03"},
            {"DIAMONDEX", "61db2021aa56ac04985a5cba"},
            {"KRP", "61fef64f649255ed1f59a48d" }
        };
        Dictionary<string, int> counter = new Dictionary<string, int>() { };
        public Form2()
        {
            InitializeComponent();
            Loop();
            foreach (var item in tokens)
            {
                counter[item.Value] = 0;
                listBox1.Items.Add(item.Key);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtTokenId.Text = tokens[(string)listBox1.SelectedItem];
                postData["tokenId"] = tokens[(string)listBox1.SelectedItem];
                counter[this.txtTokenId.Text] = 0;
                this.listBox1.SelectedItem = this.txtTokenId.Text;
            }
            catch (Exception) { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EventsEnabled();
            counter[this.txtTokenId.Text] = 0;
            postData["tokenId"] = this.txtTokenId.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EventsDisabled();
        }
        private void EventsDisabled()
        {
            this.lblStatus.Text = "Not Working";
            this.btnStop.Enabled = false;
            this.btnStart.Enabled = true;
            this.listBox1.Enabled = true;
            this.txtTokenId.Enabled = true;
            this.numericUpDown1.Enabled = true;
            this.numericUpDown2.Enabled = true;
        }
        private void EventsEnabled()
        {
            this.lblStatus.Text = "Working";
            this.btnStart.Enabled = false;
            this.btnStop.Enabled = true;
            this.listBox1.Enabled = false;
            this.txtTokenId.Enabled = false;
            this.numericUpDown1.Enabled = false;
            this.numericUpDown2.Enabled = false;
        }
        private async void Loop()
        {
            while (true)
            {
                try
                {
                    for (var i = 0; counter[this.txtTokenId.Text] <= ((int)this.numericUpDown2.Value) && this.btnStop.Enabled; counter[this.txtTokenId.Text]++)
                    {
                        EventsEnabled();
                        string response = await syncFirstPageTokens();
                        if (!response.Contains("\"success\""))
                        {
                            EventsDisabled();
                            continue;
                        }
                        this.lblVoteCounter.Text = counter[this.txtTokenId.Text] + "";
                    }
                    EventsDisabled();
                }
                catch (Exception)
                {

                }
                await Task.Delay(1);
            }
        }
        private async Task<string> syncFirstPageTokens()
        {
            await Task.Delay(1000-((int)this.numericUpDown1.Value));
            var data = new FormUrlEncodedContent(postData);
            var response = await client.PostAsync("https://api-vote.coinhunters.cc/token/vote", data);
            return (await response.Content.ReadAsStringAsync()).ToString();
        }

        private void txtTokenId_TextChanged(object sender, EventArgs e)
        {
            if (!tokens.Values.Contains(this.txtTokenId.Text))
            {
                this.listBox1.SelectedIndex = -1;
            }
        }
    }
}
