namespace BezeqApi.Controllers;

[ApiController]
[Route("customers")]
public class CustomerController : ControllerBase {
    private readonly MyContext context;

    public CustomerController(MyContext context) {
        this.context = context;
    }


    [Obsolete("Udi thinks this is Obsolete")]
    [HttpGet]
    public IActionResult Index() {
        return Ok();
    }
}
