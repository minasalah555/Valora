using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Valora.Services;
using Valora.ViewModels;
using Valora.DTOs;

namespace Valora.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: Order/Index - List all orders for current user
        public async Task<IActionResult> Index()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userId))
                {
                    return RedirectToAction("Login", "Account");
                }

                var orders = await _orderService.GetUserOrders(userId);
                return View(orders);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error loading orders: {ex.Message}";
                return View(new List<OrderDTO>());
            }
        }

        // GET: Order/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var order = await _orderService.GetOrderDetails(id);
                if (order == null)
                {
                    TempData["Error"] = "Order not found";
                    return RedirectToAction(nameof(Index));
                }

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (order.UserId != userId && !User.IsInRole("Admin"))
                {
                    TempData["Error"] = "You don't have permission to view this order";
                    return RedirectToAction(nameof(Index));
                }

                return View(order);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error loading order details: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Order/Create
        public IActionResult Create(int? cartId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var model = new CreateOrderViewModel
            {
                UserId = userId,
                CartId = cartId
            };

            return View(model);
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateOrderViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userId))
                {
                    return RedirectToAction("Login", "Account");
                }

                model.UserId = userId;
                var order = await _orderService.CreateOrder(model);

                TempData["Success"] = "Order created successfully!";
                return RedirectToAction(nameof(Details), new { id = order.ID });
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error creating order: {ex.Message}";
                return View(model);
            }
        }

        // GET: Order/Cancel/5
        public async Task<IActionResult> Cancel(int id)
        {
            try
            {
                var order = await _orderService.GetOrderDetails(id);
                if (order == null)
                {
                    TempData["Error"] = "Order not found";
                    return RedirectToAction(nameof(Index));
                }

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (order.UserId != userId && !User.IsInRole("Admin"))
                {
                    TempData["Error"] = "You don't have permission to cancel this order";
                    return RedirectToAction(nameof(Index));
                }

                if (order.OrderStatus == "Delivered" || order.OrderStatus == "Cancelled")
                {
                    TempData["Error"] = $"Cannot cancel order with status: {order.OrderStatus}";
                    return RedirectToAction(nameof(Details), new { id });
                }

                return View(order);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error loading order: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Order/Cancel/5
        [HttpPost, ActionName("Cancel")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelConfirmed(int id)
        {
            try
            {
                var result = await _orderService.CancelOrder(id);
                if (result)
                {
                    TempData["Success"] = "Order cancelled successfully";
                }
                else
                {
                    TempData["Error"] = "Failed to cancel order";
                }

                return RedirectToAction(nameof(Details), new { id });
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error cancelling order: {ex.Message}";
                return RedirectToAction(nameof(Details), new { id });
            }
        }

        // GET: Order/ManageOrders - Admin only
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ManageOrders()
        {
            try
            {
                var orders = await _orderService.GetAllOrders();
                return View(orders);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error loading orders: {ex.Message}";
                return View(new List<OrderDTO>());
            }
        }

        // GET: Order/UpdateStatus/5 - Admin only
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStatus(int id)
        {
            try
            {
                var order = await _orderService.GetOrderDetails(id);
                if (order == null)
                {
                    TempData["Error"] = "Order not found";
                    return RedirectToAction(nameof(ManageOrders));
                }

                var model = new UpdateOrderStatusViewModel
                {
                    OrderId = order.OrderId,
                    OrderStatus = order.OrderStatus,
                    ShippedDate = order.ShippedDate,
                    DeliveredDate = order.DeliveredDate,
                    Notes = order.Notes
                };

                return View(model);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error loading order: {ex.Message}";
                return RedirectToAction(nameof(ManageOrders));
            }
        }

        // POST: Order/UpdateStatus/5 - Admin only
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStatus(UpdateOrderStatusViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var result = await _orderService.UpdateOrderStatus(model);
                if (result)
                {
                    TempData["Success"] = "Order status updated successfully";
                    return RedirectToAction(nameof(Details), new { id = model.OrderId });
                }
                else
                {
                    TempData["Error"] = "Failed to update order status";
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error updating order status: {ex.Message}";
                return View(model);
            }
        }
    }
}