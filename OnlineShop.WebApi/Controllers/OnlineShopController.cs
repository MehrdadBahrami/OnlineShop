using Microsoft.AspNetCore.Mvc;
using OnlineShop.DomainLayer.Models;
using OnlineShop.ServiceLayer.Contract;


// Request models for clarity in the controller methods
public class AddCartItemRequest
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}

public class UpdateCartItemQuantityRequest
{
    public int NewQuantity { get; set; }
}

public class ChangePasswordRequest
{
    public string? NewPassword { get; set; }
}

public class UpdateOrderStatusRequest
{
    public string? NewStatus { get; set; }
}

namespace OnlineShop.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OnlineShopController : Controller
    {
        private readonly ICartService _cartService;
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public OnlineShopController(
            ICartService cartService,
            ICustomerService customerService,
            IOrderService orderService,
            IProductService productService)
        {
            _cartService = cartService;
            _customerService = customerService;
            _orderService = orderService;
            _productService = productService;
        }
        #region Cart-related endpoints
        /// <summary>
        /// Retrieves the shopping cart for a specific customer.
        /// </summary>
        [HttpGet("cart/{customerId}")]
        public async Task<ActionResult<Cart>> GetCartByCustomerId(int customerId)
        {
            var cart = await _cartService.GetCartByCustomerIdAsync(customerId);
            if (cart == null)
            {
                return NotFound();
            }

            return Ok(cart);
        }
        /// <summary>
        /// Adds a specified quantity of a product to the customer's shopping cart.
        /// </summary>
        [HttpPost("cart/{customerId}/addItem")]
        public async Task<ActionResult> AddItemToCart(int customerId, [FromBody] AddCartItemRequest request)
        {
            await _cartService.AddItemToCartAsync(customerId, request.ProductId, request.Quantity);
            return Ok();
        }
        /// <summary>
        /// Removes a specific item from the customer's shopping cart.
        /// </summary>
        [HttpDelete("cart/{customerId}/removeItem/{cartItemId}")]
        public async Task<ActionResult> RemoveItemFromCart(int customerId, int cartItemId)
        {
            await _cartService.RemoveItemFromCartAsync(customerId, cartItemId);
            return Ok();
        }
        /// <summary>
        /// Retrieves the total value of the customer's shopping cart.
        /// </summary>
        [HttpGet("cart/{customerId}/total")]
        public async Task<ActionResult<decimal>> GetCartTotal(int customerId)
        {
            var total = await _cartService.GetCartTotalAsync(customerId);
            return Ok(total);
        }
        /// <summary>
        /// Updates the quantity of a specific item in the customer's shopping cart.
        /// </summary>
        [HttpPut("cart/updateQuantity/{cartItemId}")]
        public async Task<ActionResult> UpdateCartItemQuantity(int cartItemId, [FromBody] UpdateCartItemQuantityRequest request)
        {
            await _cartService.UpdateCartItemQuantityAsync(cartItemId, request.NewQuantity);
            return Ok();
        }
        #endregion
        #region Customer-related endpoints
        /// <summary>
        /// Retrieves a customer by their unique identifier.
        /// </summary>
        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int customerId)
        {
            var customer = await _customerService.GetCustomerByIdAsync(customerId);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }
        /// <summary>
        /// Retrieves a customer by their email address.
        /// </summary>
        [HttpGet("customer/byEmail/{email}")]
        public async Task<ActionResult<Customer>> GetCustomerByEmail(string email)
        {
            var customer = await _customerService.GetCustomerByEmailAsync(email);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }
        /// <summary>
        /// Registers a new customer.
        /// </summary>
        [HttpPost("customer/register")]
        public async Task<ActionResult> RegisterCustomer(Customer customerModel)
        {
            await _customerService.RegisterCustomerAsync(customerModel);
            return Ok();
        }
        /// <summary>
        /// Updates the profile of an existing customer.
        /// </summary>
        [HttpPut("customer/updateProfile")]
        public async Task<ActionResult> UpdateCustomerProfile([FromBody] Customer customerModel)
        {
            await _customerService.UpdateCustomerProfileAsync(customerModel);
            return Ok();
        }
        /// <summary>
        /// Changes the password for a customer.
        /// </summary>
        [HttpPut("customer/changePassword/{customerId}")]
        public async Task<ActionResult> ChangePassword(int customerId, [FromBody] ChangePasswordRequest request)
        {
            await _customerService.ChangePasswordAsync(customerId, request.NewPassword);
            return Ok();
        }
        #endregion
        #region Order-related endpoints
        /// <summary>
        /// Places a new order for a customer.
        /// </summary>
        [HttpPost("order/placeOrder/{customerId},{orderId}")]
        public async Task<ActionResult<Order>> PlaceOrder(int orderId, int customerId, [FromBody] List<CartItem> cartItems)
        {
            var order = await _orderService.PlaceOrderAsync(orderId, customerId, cartItems);
            return Ok(order);
        }
        /// <summary>
        /// Retrieves an order by its unique identifier.
        /// </summary>
        [HttpGet("order/{orderId}")]
        public async Task<ActionResult<Order>> GetOrderById(int orderId)
        {
            var order = await _orderService.GetOrderByIdAsync(orderId);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }
        /// <summary>
        /// Retrieves a list of orders for a specific customer.
        /// </summary>
        [HttpGet("order/byCustomer/{customerId}")]
        public async Task<ActionResult<List<Order>>> GetOrdersByCustomer(int customerId)
        {
            var orders = await _orderService.GetOrdersByCustomerAsync(customerId);
            return Ok(orders);
        }
        /// <summary>
        /// Cancels an existing order.
        /// </summary>
        [HttpPut("order/cancel/{orderId}")]
        public async Task<ActionResult> CancelOrder(int orderId)
        {
            await _orderService.CancelOrderAsync(orderId);
            return Ok();
        }
        /// <summary>
        /// Updates the status of an existing order.
        /// </summary>
        [HttpPut("order/updateStatus/{orderId}")]
        public async Task<ActionResult> UpdateOrderStatus(int orderId, [FromBody] UpdateOrderStatusRequest request)
        {
            await _orderService.UpdateOrderStatusAsync(orderId, request.NewStatus);
            return Ok();
        }
        #endregion
        #region Product-related endpoints
        /// <summary>
        /// Retrieves a product by its unique identifier.
        /// </summary>
        [HttpGet("product/{productId}")]
        public async Task<ActionResult<Product>> GetProductById(int productId)
        {
            var product = await _productService.GetProductByIdAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
        /// <summary>
        /// Adds a new product.
        /// </summary>
        [HttpPost("product/add")]
        public async Task<ActionResult> AddProduct([FromBody] Product productModel)
        {
            await _productService.AddProductAsync(productModel);
            return Ok();
        }
        /// <summary>
        /// Updates an existing product.
        /// </summary>
        [HttpPut("product/update")]
        public async Task<ActionResult> UpdateProduct([FromBody] Product productModel)
        {
            await _productService.UpdateProductAsync(productModel);
            return Ok();
        }
        /// <summary>
        /// Deletes a product by its unique identifier.
        /// </summary>
        [HttpDelete("product/delete/{productId}")]
        public async Task<ActionResult> DeleteProduct(int productId)
        {
            await _productService.DeleteProductAsync(productId);
            return Ok();
        }
        /// <summary>
        /// Retrieves a list of all products.
        /// </summary>
        [HttpGet("product/all")]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }
        #endregion
    }
}
