using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using QRasta.Helpers;
using QRCoder;

namespace QRasta.Controllers;

[ApiController]
[Route("[controller]")]
public class GenerateController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<GenerateController> _logger;

    public GenerateController(ILogger<GenerateController> logger)
    {
        _logger = logger;
    }

    [HttpGet()]
    public async Task<IActionResult> Get(string Url, [Range(3,15)] int ppm = 5)
    {
        
        // https://www.prizegives.com/aus/c359ebad-6482-4f4d-acf0-97893959164c/b672ae49-3a50-44b4-b4a5-bbbd7ce4695a/a1691851-fe30-406a-8194-e1e0893350db/login?id=bXVzTGErMUNDV3hvT1pEQ3AzblZ4UmQxc1J4T3V4MFpKbTNHdEJkYVRZdnJHYUhWbitUcXVPWDBNNjNMNWxWanNqbDRRUlZSaGFVL2N1cUw0MjFaVW1rNzB2c0E0K05tdnNaU1BqYmw0eVpZNktmNU14WHhHZ0QxUGUxOGVnMEhtcXVNMGJEVkhKd1k5OEEwZTNUL3c4WGQwZzlzbWd5eGhDRjBQd1Q2NU0rNURqYzdtaTdsTjZBc2JMS0lPWmxMVk1LdUxhcExqRGMxT050SzZGR1F5ZStYZ1pWdUI2OU9FSy91QkFXMktWbnBQY2tvb2ZyQUR6TzFWdHNmT3lmVFM5R0IwWlhYbWRXbnhHamthcnpySTh0cm5jQjdLMDZZeURqYVpKUWJUb01ZQTBlSTlNbE9OOXBHamVoQjdYa1RrWGVHd2FnMEpQQU54MEFmd3lJbWJ1QUNhSVVyckdhUER0Y1lLN3ZYMml3PQ
        
        // https://www.prizegives.com/aus/{tenant_id}/{simulation_id}/a1691851-fe30-406a-8194-e1e0893350db/login?id=<random_id?>
        
        // (^([0-9A-Fa-f]{8}[-]?[0-9A-Fa-f]{4}[-]?[0-9A-Fa-f]{4}[-]?[0-9A-Fa-f]{4}[-]?[0-9A-Fa-f]{12})$)
        
        // Determine URL validity b672ae49-3a50-44b4-b4a5-bbbd7ce4695a
        ASTUrl astUrl = new ASTUrl(Url);

        if (!astUrl.IsValid())
            return BadRequest("QRasta only supports generating QR codes for the purpose of attack simulation training!");
        
        // Generate QR Code
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(Url, QRCodeGenerator.ECCLevel.Q);
        
        PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
        byte[] qrCodeAsPngByteArr = qrCode.GetGraphic(ppm);

        return new FileContentResult(qrCodeAsPngByteArr, "image/png");
    }
}
