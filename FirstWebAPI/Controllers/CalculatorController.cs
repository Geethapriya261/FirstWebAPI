using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        //api/calculator/add?x=10&y=2
        [HttpGet("Calculator/Add")]  
        public int Add(int x , int y)
        {
            return x + y;
        }
        [HttpGet("Calculator/Sum")]
        public int Sum(int x, int y)
        {
            return x + y+500;
        }
        //api/calculator/subtract?x=5&y=3
        [HttpPost("Calculator/Subtract")]
        public int Subtract(int x, int y)
        {
            return x - y;
        }
        //api/calculator/multiply?x=5&y=3
        [HttpPut("Calculator/Multiply")]
        public int Multiply(int x, int y)
        {
            return x * y;
        }
        //api/calculator/divide?x=15&y=3
        [HttpDelete("Calculator/Divide")]

        public int Divide(int x, int y)
        {
            return x / y;
        }
    }
}
