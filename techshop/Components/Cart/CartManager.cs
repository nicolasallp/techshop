using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using techshop.DataManager;
using techshop.Models.Entities;

namespace techshop.Components.Cart
{
    public static class CartManager
    {
        public static async void AddToCart(string? userId, Models.Entities.Product product, List<CartProduct>? cartProducts, CartProduct? cartProduct, bool isInCart, CartState cartCounter)
        {
            if (isInCart && cartProduct != null)
            {
                isInCart = false;
                await ApiRequest.DeleteData(RequestURL.CartProducts, cartProduct.Id!);
                cartProducts = await ApiRequest.GetData<CartProduct>(RequestURL.CartProducts, userId!);
                cartCounter.SendCount(cartProducts?.Count ?? 0);
                return;
            }

            isInCart = true;
            string data = JsonConvert.SerializeObject(new CartProduct
            {
                UserId = userId,
                ProductId = product!.Id,
                Quantity = 1
            });

            await ApiRequest.CreateData(RequestURL.CartProducts, data);
            cartProducts = await ApiRequest.GetData<CartProduct>(RequestURL.CartProducts, userId!);
            cartCounter.SendCount(cartProducts?.Count ?? 0);
            cartProduct = cartProducts!.Where(p => p.ProductId == product!.Id).FirstOrDefault();
            return;
        }

        public static async Task UpdateQuantity(int operation, CartProduct cartProduct, EventCallback<decimal> onQuantityUpdate)
        {
            if (cartProduct!.Quantity == 1 && operation < 0)
            {
                return;
            }
            cartProduct!.Quantity += operation;

            string data = JsonConvert.SerializeObject(new CartProduct
            {
                UserId = cartProduct.UserId,
                ProductId = cartProduct.ProductId,
                Quantity = cartProduct.Quantity
            });
            await ApiRequest.UpdateData(RequestURL.CartProducts, cartProduct.Id!, data);

            await onQuantityUpdate.InvokeAsync(cartProduct.Quantity);
        }
    }
}
