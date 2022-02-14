using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
namespace coinhunters_cc_vote_bot_ui
{
    public partial class Form1 : Form
    {
        private HttpClient client = new HttpClient();
        public Form1()
        {
            InitializeComponent();
            startLoops();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.textBox1.Enabled = this.checkBox1.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.button2.Enabled = false;
            this.button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            this.button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Thread.Sleep(1000);
            this.Cursor = Cursors.Default;
        }
        private async void startLoops()
        {
            while (true)
            {
                var x = await syncFirstPageTokens();
                Console.WriteLine(x);
            }
        }

        private async Task syncFirstPageTokens()
        {
            await Task.Delay(1);
            var x = await client.GetAsync("https://api-vote.coinhunters.cc/token/list/todayUpVotes/0");
            var y = await x.Content.ReadAsStringAsync();
            //var z = JsonConvert.DeserializeObject<object>(y);
            /*var client = new HttpClient();
            string reqUrl = $"https://api-vote.coinhunters.cc/token/list/todayUpVotes/0";
            var prodResp = await client.GetAsync(reqUrl);
            if (!prodResp.IsSuccessStatusCode)
            {
                return;
            }
            var prods = await prodResp.Content.ReadAsStringAsync();*/
        }
    }
}
