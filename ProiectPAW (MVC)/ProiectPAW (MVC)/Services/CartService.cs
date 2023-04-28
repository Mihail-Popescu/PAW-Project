using ProiectPAW__MVC_.Models;
using ProiectPAW__MVC_.Repositories;

public class CartService
{
    private readonly OrderRepository _orderRepository;
    private readonly OrderItemRepository _orderItemRepository;
    private readonly ProductRepository _productRepository;

    public CartService(OrderRepository orderRepository, OrderItemRepository orderItemRepository, ProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _orderItemRepository = orderItemRepository;
        _productRepository = productRepository;
    }

    public async Task<int> AddToCartAsync(int productId, int customerId)
    {
        var product = await _productRepository.GetProductByIdAsync(productId);
        if (product == null)
        {
            return -1; // product not found
        }

        var order = await _orderRepository.GetCartByCustomerIdAsync(customerId);
        if (order == null)
        {
            order = new Order
            {
                OrderDate = DateTime.Now,
                TotalPrice = product.Price,
                CustomerId = customerId
            };
            await _orderRepository.AddOrderAsync(order);
        }
        else
        {
            order.TotalPrice += product.Price;
            await _orderRepository.UpdateOrderAsync(order);
        }

        var orderItem = new OrderItem
        {
            Quantity = 1,
            OrderId = order.OrderId,
            ProductId = productId
        };
        await _orderItemRepository.AddOrderItemAsync(orderItem);

        return (int)order.OrderId;
    }

    public async Task<bool> RemoveFromCartAsync(int orderItemId)
    {
        var orderItem = await _orderItemRepository.GetOrderItemByIdAsync(orderItemId);
        if (orderItem == null)
        {
            throw new Exception("orderItem is null");
        }

        var order = await _orderRepository.GetOrderByIdAsync((int)orderItem.OrderId);
        if (order == null)
        {
            throw new Exception("order is null");
        }

        order.TotalPrice -= orderItem.Product.Price * orderItem.Quantity;

        await _orderRepository.UpdateOrderAsync(order);
        await _orderItemRepository.RemoveOrderItemAsync(orderItemId);

        return true;
    }
}