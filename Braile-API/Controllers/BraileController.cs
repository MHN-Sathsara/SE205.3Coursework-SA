using Braile_API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Braile_API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BraileController : Controller
	{

		[HttpGet]
		[Route("api/[controller]/GetShapes")]
		public IEnumerable<string> GetShapes()
		{
			List<string> shapes = new()
			{
				typeof(Circle).Name,
				typeof(Triangle).Name,
				typeof(Rectangle).Name
			};
			return shapes;
		}

		[HttpPost]
		[Route("api/[controller]/GetPerimeter")]
		public IActionResult GetPerimeter(string shape, double[] dimentions)
		{
			try
			{
				IShape SelectedShape = ShapeFactory.CreateShape(shape, dimentions);

				return Ok(SelectedShape.PerimeterCal());

			}catch (Exception ex)
			{
				return BadRequest(ex.Message); //Error Message is shown when invalid shape is Selected
			}
		}

		[HttpGet("convert")]
		public ActionResult<string> ConvertToBraille(string text)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				return BadRequest("Invalid input");
			}

			var braille = BrailleMap.ConvertToBraille(text);
			return Ok(braille);
		}

		[HttpGet("dotcount")]
		public ActionResult<int> GetDotCount(string text)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				return BadRequest("Invalid input");
			}

			var dotCount = BrailleMap.GetDotCount(text);
			return Ok(dotCount);
		}

	}
}
