using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using ClientSubscribe.CertCheck;
using MQTTnet;
using MQTTnet.Client;

namespace ClientSubscribe.Mqtt{
    public class MqttImpl{

        private IMqttClient? mqttClient;

        public MqttImpl(){
            Connect_Client1();
        }

        public async Task Clean_Disconnect(){
            var mqttFactory = new MqttFactory();

            try{
                await mqttClient!.DisconnectAsync(new MqttClientDisconnectOptionsBuilder().WithReason(MqttClientDisconnectOptionsReason.NormalDisconnection).Build());
            }catch{
                Console.WriteLine("=========================================");
                Console.WriteLine("Clean Disconnect failed ...");
                Console.WriteLine("=========================================");
            }
        }

        public async Task Connect_Client(){
            var mqttFactory = new MqttFactory();

            try{
                mqttClient = mqttFactory.CreateMqttClient();

                var tlsOptions = new MqttClientOptionsBuilderTlsParameters{
                    UseTls = true,
                    Certificates = new List<X509Certificate>{
                        new X509Certificate("mosquitto.org.crt")
                    },
                    AllowUntrustedCertificates = true,
                    IgnoreCertificateChainErrors = true,
                    IgnoreCertificateRevocationErrors = true,
                    CertificateValidationHandler = eventArgs => {
                        Console.WriteLine(eventArgs.Certificate.Subject);
                        Console.WriteLine(eventArgs.Certificate.GetExpirationDateString());
                        Console.WriteLine(eventArgs.Chain.ChainPolicy.RevocationMode);
                        Console.WriteLine(eventArgs.Chain.ChainStatus);
                        Console.WriteLine(eventArgs.SslPolicyErrors);
                        
                        ICertCheck checkers = new ExpirationDateChecker();

                        return checkers.IsValid(eventArgs);
                    }
                };

                var mqttClientOptions = new MqttClientOptionsBuilder()
                    .WithTcpServer("test.mosquitto.org", 8883)
                    .WithTls(tlsOptions)
                    .WithWillQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)
                    .Build();

                mqttClient.ApplicationMessageReceivedAsync += e => {
                    Console.WriteLine("Received application message.");
                    Console.WriteLine(e.ApplicationMessage);
                    return Task.CompletedTask;
                };

                var mqttSubscribeOptions = mqttFactory.CreateSubscribeOptionsBuilder()
                .WithTopicFilter(
                    f =>
                    {
                        f.WithTopic("samples/temperature/living_room");
                    })
                .Build();
                
                var response = await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);
                await mqttClient.SubscribeAsync(mqttSubscribeOptions, CancellationToken.None);
                
                Console.WriteLine("The MQTT client is connected.");
            }catch(Exception e){
                Console.WriteLine("=========================================");
                Console.WriteLine("Connect client failed ...");
                Console.WriteLine($"{e.Message}");
                Console.WriteLine("=========================================");
            }
        }

        public async Task Connect_Client1(){
            var mqttFactory = new MqttFactory();

            try{
                mqttClient = mqttFactory.CreateMqttClient();

                var tlsOptions = new MqttClientOptionsBuilderTlsParameters{
                    UseTls = true,
                    Certificates = new List<X509Certificate>{
                        new X509Certificate("mosquitto.org.crt")
                    },
                    AllowUntrustedCertificates = true,
                    IgnoreCertificateChainErrors = true,
                    IgnoreCertificateRevocationErrors = true,
                    CertificateValidationHandler = eventArgs => {
                        Console.WriteLine(eventArgs.Certificate.Subject);
                        Console.WriteLine(eventArgs.Certificate.GetExpirationDateString());
                        Console.WriteLine(eventArgs.Chain.ChainPolicy.RevocationMode);
                        Console.WriteLine(eventArgs.Chain.ChainStatus);
                        Console.WriteLine(eventArgs.SslPolicyErrors);
                        
                        ICertCheck checkers = new ExpirationDateChecker();

                        return checkers.IsValid(eventArgs);
                    }
                };

                var mqttClientOptions = new MqttClientOptionsBuilder()
                    .WithTcpServer("test.mosquitto.org", 8883)
                    .WithTls(tlsOptions)
                    .WithWillQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)
                    .Build();

                _ = Task.Run(
                    async() => {
                        while (true){
                            try{
                                if (!await mqttClient.TryPingAsync()){
                                    mqttClient.ApplicationMessageReceivedAsync += e => {
                                        Console.WriteLine("Received application message.");
                                        Console.WriteLine(e.ApplicationMessage);
                                        return Task.CompletedTask;
                                    };

                                    var mqttSubscribeOptions = mqttFactory.CreateSubscribeOptionsBuilder()
                                    .WithTopicFilter(
                                        f =>
                                        {
                                            f.WithTopic("samples/temperature/living_room");
                                        })
                                    .Build();
                                    
                                    var response = await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);
                                    await mqttClient.SubscribeAsync(mqttSubscribeOptions, CancellationToken.None);
                                    
                                    Console.WriteLine("The MQTT client is connected.");
                                }
                            }catch{
                                Console.WriteLine("Failed ...");
                            }finally{
                                await Task.Delay(TimeSpan.FromSeconds(5));
                            }
                        }
                    }
                );
            }catch(Exception e){
                Console.WriteLine("=========================================");
                Console.WriteLine("Connect client failed ...");
                Console.WriteLine($"{e.Message}");
                Console.WriteLine("=========================================");
            }
        }


        public async Task Publish_Application_Message(){
            if (mqttClient == null || !mqttClient.IsConnected){
                await Connect_Client1();
            }

            try{
                var applicationMessage = new MqttApplicationMessageBuilder()
                    .WithTopic("samples/temperature/living_room")
                    .WithPayload("19.5")
                    .Build();

                await mqttClient.PublishAsync(applicationMessage, CancellationToken.None);

                Console.WriteLine("MQTT application message is published.");
            }catch (Exception e){
                Console.WriteLine("=========================================");
                Console.WriteLine(e.Message);
                Console.WriteLine("=========================================");
            }
        }

        


    }
}