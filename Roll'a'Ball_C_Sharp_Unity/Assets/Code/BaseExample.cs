

namespace GeekBrains
{
    public class BaseExample<T>
    {
        public T IdPlayer = default;

        public BaseExample(T id)
        {
            IdPlayer = id;
        }
    }
}
