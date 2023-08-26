
//DesignPattern.Command.Startup.Execute();


using Confluent.Kafka;

var config = new ProducerConfig
{
    BootstrapServers = "localhost:9092",
};

using (var producer = new ProducerBuilder<Null, string>(config).Build())
{
    string topic = "test";
    string message = "{\"title\": \"Push messages to Kafka from .NET-6\",\"author\": \"Anja Reddy Gaddam\",\"genre\": \"Learn Kafka\",\"year\": 2023,\"isbn\": \"1501173319\"}";

    var deliveryReport = producer.ProduceAsync(topic, new Message<Null, string> { Value = message });
    deliveryReport.ContinueWith(task =>
    {
        Console.WriteLine($"Message delivered to {task.Result.TopicPartitionOffset}");
    });

    producer.Flush(TimeSpan.FromSeconds(10));
}

Console.ReadKey();
