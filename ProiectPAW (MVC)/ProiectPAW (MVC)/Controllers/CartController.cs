using Microsoft.AspNetCore.Mvc;
using ProiectPAW__MVC_.Models;
using ProiectPAW__MVC_.Repositories;

namespace ProiectPAW__MVC_.Controllers
{
    public class CartController : Controller
    {
        private readonly CartService _cartService;
        private readonly OrderItemRepository _orderItemRepository;
        private readonly OrderRepository _orderRepository;

        public CartController(CartService cartService, OrderItemRepository orderItemRepository, OrderRepository orderRepository)
        {
            _cartService = cartService;
            _orderItemRepository = orderItemRepository;
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId)
        {
            // In a real-world scenario, you would typically associate the order with a user ID, 
            // but for the purposes of this example, let's just hardcode a user ID
            var customerId = 1;

            var orderId = await _cartService.AddToCartAsync(productId, customerId);
            if (orderId == -1)
            {
                return NotFound(); // product not found
            }

            var referer = Request.Headers["Referer"].ToString(); // get the previous URL
            return Redirect(referer);
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFromCart(int orderItemId)
        {
            var success = await _cartService.RemoveFromCartAsync(orderItemId);
            if (!success)
            {
                return NotFound(); // order item not found or order already submitted
            }

            var referer = Request.Headers["Referer"].ToString(); // get the previous URL
            return Redirect(referer);
        }
        public async Task<IActionResult> Cart()
        {
            var customerId = 1; // Replace with actual customer ID
            var order = await _orderRepository.GetActiveOrderByCustomerIdAsync(customerId);
            if (order == null)
            {
                return View(new List<OrderItem>());
            }
            var cartItems = await _orderItemRepository.GetOrderItemsByOrderIdAsync((int)order.OrderId);
            return View(cartItems);
        }
    }

};