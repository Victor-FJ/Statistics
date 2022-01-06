using CC.Mediator;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace Statistics.Controllers
{
    public class NswagController : MediatorController
    {
        //private readonly IMediator _mediator;
        //public NswagController(IMediator mediator)
        //{
        //    _mediator = mediator;
        //}

        //protected async new ActionResult<TResponse> SendRequest<TResponse>(IRequest<TResponse> request)
        //{
        //    var result = await _mediator.SendAsync(request);
        //    var response = new ActionResult<TResponse>(result.Value);
        //    return response;
        //}

        //Normal one
        protected async new Task<ActionResult<TResponse>> SendRequest<TResponse>(IRequest<TResponse> request)
        {
            var result = await base.SendRequest(request);
            var response = new ActionResult<TResponse>((ActionResult)result);
            return response;
        }

        ////Save
        //protected async new Task<ActionResult<TResponse>> SendRequest<TResponse>(IRequest<TResponse> request)
        //{
        //    var result = await base.SendRequest(request);
        //    var response = new ActionResult<TResponse>((ActionResult)result);

        //    string jsonText = JsonConvert.SerializeObject(response);
        //    using StreamWriter writer = new(GetName(request));
        //    writer.Write(jsonText);
        //    return response;
        //}

        ////Load
        //protected async new Task<ActionResult<TResponse>> SendRequest<TResponse>(IRequest<TResponse> request)
        //{
        //    using StreamReader reader = new(GetName(request));
        //    string jsonText = reader.ReadToEnd();
        //    ActionResult<TResponse> response = JsonConvert.DeserializeObject<ActionResult<TResponse>>(jsonText);
        //    return response;
        //}

        private string GetName(object request)
            => Path.Combine(@"C:\Users\vfj\Documents\Backup data", request.GetType().Name + "File.txt");
    }
}
