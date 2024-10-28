using BuilderPatternAPI.Models;
using BuilderPatternAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api")]
public class ProductsController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }

    // Метод для получения всех продуктов
    [HttpGet("products-all")]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _productService.GetAllProductsAsync(); // Получаем все продукты асинхронно
        return Ok(new ApiResponse { Data = products });
    }

    // Метод для получения продуктов с фильтрацией
    [HttpPost("filter")]
    public async Task<IActionResult> CreateProducts([FromBody] ProductSearchRequest request)
    {
        if (request == null || string.IsNullOrEmpty(request.Category))
        {
            return BadRequest(new ApiResponse { Error = "Отсутствуют данные для корректного вывода." });
        }

        // Логика обработки фильтрации
        var products = await _productService.SearchProductsAsync(request); // Применяем фильтры асинхронно
        return Ok(new ApiResponse { Data = products });
    }

    // Метод для получения продукта по его идентификатору
    [HttpGet("products/{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await _productService.GetProductByIdAsync(id); // Получаем продукт асинхронно
        if (product == null)
        {
            return NotFound(new ApiResponse { Error = "Продукт не найден." });
        }
        return Ok(product);
    }

    // Метод для создания нового продукта
    [HttpPost("products")]
    public async Task<IActionResult> CreateProduct([FromBody] Product product)
    {
        if (product == null)
        {
            return BadRequest(new ApiResponse { Error = "Не получается создать." });
        }
        await _productService.CreateProductAsync(product); // Создаем продукт асинхронно
        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }

    // Метод для обновления существующего продукта
    [HttpPut("products/{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
    {
        if (id != product.Id)
        {
            return BadRequest(new ApiResponse { Error = "Продукты не обновлён." });
        }
        var existingProduct = await _productService.GetProductByIdAsync(id); // Получаем продукт асинхронно
        if (existingProduct == null)
        {
            return NotFound();
        }
        await _productService.UpdateProductAsync(product); // Обновляем продукт асинхронно
        return NoContent();
    }

    // Метод для удаления продукта
    [HttpDelete("products/{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var existingProduct = await _productService.GetProductByIdAsync(id); // Получаем продукт асинхронно
        if (existingProduct == null)
        {
            return NotFound(new ApiResponse { Error = "Объект для удаления не найден." });
        }
        await _productService.DeleteProductAsync(id); // Удаляем продукт асинхронно
        return NoContent();
    }
}
