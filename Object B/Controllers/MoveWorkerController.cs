using Microsoft.AspNetCore.Mvc;
using Object_B.Models.Context;
using Object_B.Services;
using Microsoft.AspNetCore.SignalR;

namespace Object_B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoveWorkerController : ControllerBase
    {
        AllDataContext context;
        IHubContext<HubService> hubContext;
        public MoveWorkerController(AllDataContext context, IHubContext<HubService> hubContext)
        {
            this.context = context;
            this.hubContext = hubContext;
        }

        
        [HttpGet("EmitationMove")]
        public ActionResult MoveWorkerEmitationAsync()
        {
            MoveEmitationService.EmitationMoveWorker(hubContext, context);
            return Ok();
        }
        [HttpGet("StopSend")]
        public IActionResult StopSend()
        {
            MoveEmitationService.StopTimerSendForListeners();
            return Ok();
        }
        
        [HttpGet("TestUDP")]
        public IActionResult testingUDP()
        {
            System.Console.WriteLine("OpenUdp. Port : 8001");
            UdpClientService.AcceptCoordinates();
            System.Console.WriteLine("CloseUpd. Port : 8001");
            return Ok();
        }
    }
}
