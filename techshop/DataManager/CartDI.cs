namespace techshop.DataManager
{
    public class CartDI
    {
        public event Action<int>? OnDataSent;
        
        public void SendCount(int count)
        {
            OnDataSent?.Invoke(count);
        }
    }
}
