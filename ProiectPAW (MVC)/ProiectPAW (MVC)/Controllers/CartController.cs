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
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            if (!customerId.HasValue)
            {
                // Redirect to login or display an error message indicating that the user must be logged in
                return RedirectToAction("Login", "Login");
            }

            var orderId = await _cartService.AddToCartAsync(productId, (int)customerId);
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
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            if (!customerId.HasValue)
            {
                // Redirect to login or display an error message indicating that the user must be logged in
                return RedirectToAction("Login", "Login");
            }

            var order = await _orderRepository.GetActiveOrderByCustomerIdAsync((int)customerId);
            if (order == null)
            {
                return View(new List<OrderItem>());
            }

            var cartItems = await _orderItemRepository.GetOrderItemsByOrderIdAsync((int)order.OrderId);
            return View(cartItems);
        }
        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> Checkout()
        {
            var customerId = HttpContext.Session.GetInt32("CustomerId");
            if (!customerId.HasValue)
            {
                // Redirect to login or display an error message indicating that the user must be logged in
                return RedirectToAction("Login", "Login");
            }

            var order = await _orderRepository.GetActiveOrderByCustomerIdAsync((int)customerId);
            if (order == null)
            {
                return NotFound(); // order not found or cart is empty
            }

            // Clear the cart
            await _cartService.ClearCartAsync((int)customerId);

            TempData["SuccessMessage"] = "Order has been placed successfully!";
            return RedirectToAction("Cart");
        }
    }

};