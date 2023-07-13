using MQTTnet.Client;

namespace ClientSubscribe.CertCheck{
    public class ExpirationDateChecker : ICertCheck
    {
        public bool IsValid(MqttClientCertificateValidationEventArgs args){
            DateTimeOffset certDateTime = DateTimeOffset.Parse(args.Certificate.GetExpirationDateString());

            long certDateTimeMilli = certDateTime.ToUnixTimeMilliseconds();
            long utcNowMilli = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            return utcNowMilli < certDateTimeMilli;
        }
    }
}