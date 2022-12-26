using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace web_app.Controllers;

[ApiController]
[Route("[controller]")]
public class CacheController : ControllerBase
{
    private readonly ILogger<CacheController> _logger;
    private readonly ConnectionMultiplexer _redis; 

    public CacheController(ILogger<CacheController> logger)
    {
        _logger = logger;
        _redis = ConnectionMultiplexer.Connect("cache:6379");
    }

    [HttpGet]
    public IActionResult Get([FromQuery]string key)
    {
        IDatabase db = _redis.GetDatabase();
        var value = db.StringGet(key);
        return Ok(value.ToString());
    }

    [HttpPost]
    public IActionResult Save([FromForm]string key, [FromForm] string value)
    {
        IDatabase db = _redis.GetDatabase();
        var saved = db.StringSet(key, value);
        return Ok(saved);
    }
}
