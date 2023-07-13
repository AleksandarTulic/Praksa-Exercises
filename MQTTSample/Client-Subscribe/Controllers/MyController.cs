using ClientSubscribe.Mqtt;
using Microsoft.AspNetCore.Mvc;

namespace ClientSubscribe.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class MyController : ControllerBase{
        
        private MqttImpl mqtt;

        public MyController(MqttImpl mqtt){
            this.mqtt = mqtt;
        }

        [HttpGet]
        public async Task<IActionResult> GetString(){
            await mqtt.Publish_Application_Message();
            return Ok("Sta ima ...");
        }

        [HttpGet("/disconnect-some")]
        public async Task DisconnectSome(){
            await mqtt.Clean_Disconnect();
        }
    }
}