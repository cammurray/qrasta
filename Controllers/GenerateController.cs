using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using QRasta.Helpers;
using QRCoder;

namespace QRasta.Controllers;

[ApiController]
[Route("[controller]")]
public class GenerateController : ControllerBase
{

    [HttpGet()]
    public async Task<IActionResult> Get(string Url, [Range(3,15)] int ppm = 5)
    {

        bool isValid = false;
        
        // If Url is the ${phishgUrl} place holder, give the something back so we can see it.
        // What better thing than a rick'roll..
        // https://www.youtube.com/watch?v=dQw4w9WgXcQ

        if (Url.ToLower() == "${phishingurl}")
        {
            Url = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
            isValid = true;
        }

        if (!isValid)
        {
            // Determine URL validity b672ae49-3a50-44b4-b4a5-bbbd7ce4695a
            ASTUrl astUrl = new ASTUrl(Url);

            if (!astUrl.IsValid())
                return BadRequest("QRasta only supports generating QR codes for the purpose of attack simulation training!");

        }
        
        // Generate QR Code
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(Url, QRCodeGenerator.ECCLevel.Q);
        
        PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
        byte[] qrCodeAsPngByteArr = qrCode.GetGraphic(ppm);

        return new FileContentResult(qrCodeAsPngByteArr, "image/png");
    }
}
