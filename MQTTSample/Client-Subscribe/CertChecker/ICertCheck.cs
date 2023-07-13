using MQTTnet.Client;

namespace ClientSubscribe.CertCheck{
    public interface ICertCheck{
        public bool IsValid(MqttClientCertificateValidationEventArgs args);
    }
}