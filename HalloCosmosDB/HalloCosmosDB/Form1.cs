using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Newtonsoft.Json;
using System.ComponentModel;

namespace HalloCosmosDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        string endpoint = "https://fred.documents.azure.com:443/";
        string key = "Zf5p2qPEvpQ1bgchR4dkFVCFUhwnzAx6koD1iSJTxq2VzdvonO1YyAJCHmCPWQcViinYPKDc5Fd5bs1qWHIhFg==";

        private async void LoadButton_Click(object sender, EventArgs e)
        {
            using (var client = new CosmosClient(endpoint, key))
            {
                var db = client.GetDatabase("Personen");
                var con = db.GetContainer("Id");

                var list = new BindingList<Person>();
                dataGridView1.DataSource = list;

                var feed = con.GetItemLinqQueryable<Person>().ToFeedIterator();

                while (feed.HasMoreResults)
                {
                    foreach (var item in await feed.ReadNextAsync())
                    {
                        list.Add(item);
                        await Task.Delay(100);
                    }
                }
            }
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            using (var client = new CosmosClient(endpoint, key))
            {
                var db = client.GetDatabase("Personen");
                var con = db.GetContainer("Id");

                var newPerson = new Person()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = $"Fred_{Guid.NewGuid().ToString().Substring(0, 4)}",
                    //Zahl = DateTime.Now.Millisecond
                };

                await con.CreateItemAsync(newPerson);
            }
        }
    }

    class Person
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Zahl { get; set; }
    }

}