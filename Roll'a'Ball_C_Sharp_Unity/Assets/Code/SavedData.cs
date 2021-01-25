

namespace GeekBrains
{
    public sealed class SavedData<T, R, U> : BaseExample<R>
        where T : U
    {
        public T Position;

        public SavedData(R id) : base(id)
        {
            IdPlayer = id;
        }
    }
}