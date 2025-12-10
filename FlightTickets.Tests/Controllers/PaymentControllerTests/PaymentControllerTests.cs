using FlightTickets.PaymentAPI.Controllers;
using FlightTickets.PaymentAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FlightTickets.Tests.Controllers.PaymentControllerTests
{
    public class PaymentControllerTests
    {

        // testando o construtor
        public ILogger<PaymentController> _logger;  // precisa dele para...
        
        public PaymentService _paymentService;  // precisa dele para...

        public PaymentController _paymentController;  // testando este cara


        public PaymentControllerTests()  // Controler do meu Tests, ele vai testar sempre o controler do payment
        {
            _logger = new LoggerFactory().CreateLogger<PaymentController>();
            _paymentService = new PaymentService();
            _paymentController = new PaymentController(_logger, _paymentService);
        }



        [Fact]
        //[Trait("VerbosHTTP", "Get")]  // criando categoria de tests
        public void ProcessPaymentMustReturnOkResult()
        {
            //Act
            var result = _paymentController.Get().Result;


            //Assert
            Assert.NotNull(result);  // verificar se o retorno não é nulo
            Assert.IsType<OkResult>(result);  // verificar se o tipo do retorno é Result


        }


    }
}
