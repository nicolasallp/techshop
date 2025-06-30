namespace techshop.DataManager
{
    public class CartState
    {
        public event Action<int>? OnChange;

        public void SendCount(int count)
        {
            OnChange?.Invoke(count);
        }
    }
}
