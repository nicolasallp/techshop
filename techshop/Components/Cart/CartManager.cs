using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.ComponentModel;
using techshop.DataManager;
using techshop.Models.Entities;

namespace techshop.Components.Cart
{
    public static class CartManager
    {
        public static async Task AddToCart(string? userId, Models.Entities.Product? product, CartProduct? cartProduct, CartState cartCounter, int quantity = 1)
        {
            string data = JsonConvert.SerializeObject(new CartProduct
            {
                UserId = userId,
                ProductId = product!.Id,
                Quantity = quantity
            });

            await ApiRequest.CreateData(RequestURL.CartProducts, data);
            List<CartProduct>? cartProducts = await ApiRequest.GetData<CartProduct>(RequestURL.CartProducts, userId!);
            cartCounter.SendCount(cartProducts?.Count ?? 0);
            cartProduct = cartProducts!.Where(p => p.ProductId == product!.Id).FirstOrDefault();
            return;
        }

        public static async Task DeleteCartProduct(string? userId, CartProduct? cartProduct, CartState cartCounter)
        {
            await ApiRequest.DeleteData(RequestURL.CartProducts, cartProduct!.Id!);
            List<CartProduct>? cartProducts = await ApiRequest.GetData<CartProduct>(RequestURL.CartProducts, userId!);
            cartCounter.SendCount(cartProducts?.Count ?? 0);
        }

        public static async Task UpdateQuantity(int operation, CartProduct? cartProduct)
        {
            if (cartProduct == null)
            {
                return;
            }
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
        }
    }
}
