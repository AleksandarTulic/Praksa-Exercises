using System.Security.Cryptography.X509Certificates;
using MQTTnet;
using MQTTnet.Client;

namespace ClientSubscribe.Mqtt{
    public class MqttImpl{

        private IMqttClient? mqttClient;

        public MqttImpl(){
            Connect_Client();
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
                    IgnoreCertificateRevocationErrors = true
                };

                var mqttClientOptions = new MqttClientOptionsBuilder()
                    .WithTcpServer("test.mosquitto.org", 8883)
                    .WithTls(tlsOptions)
                    .WithWillQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce)
                    .Build();

                var response = await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

                Console.WriteLine("The MQTT client is connected.");
            }catch{
                Console.WriteLine("=========================================");
                Console.WriteLine("Connect client failed ...");
                Console.WriteLine("=========================================");
            }
        }


        public async Task Publish_Application_Message(){
            if (mqttClient == null || !mqttClient.IsConnected){
                await Connect_Client();
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