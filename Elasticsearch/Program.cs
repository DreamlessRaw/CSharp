using Nest;
using System;
using System.Text.Json.Serialization;

namespace Elasticsearch
{
    class Program
    {
        private static ElasticClient Client;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello ElasticSearch!");
            InitClient();

            #region 写入
            //var model = new Default
            //{
            //    Id = 1,
            //    Name = "小小"
            //};
            //var response = Client.IndexDocument(model);
            //Console.WriteLine("写入完成!!!");
            #endregion

            #region 读取
            var result = Client.Search<Default>(s => s.From(0).Size(10).Query(q => q.Match(m => m.Field(f => f.Name).Query("小"))));
            var data = result.Documents;
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(data));
            Console.ReadKey();
            #endregion
        }


        private static void InitClient()
        {
            var connectionSettings = new ConnectionSettings(new Uri("http://192.168.1.179:9200"))
                  .DefaultIndex("default");
            Client = new ElasticClient(connectionSettings);

        }

    }
}
