

namespace GeekBrains
{
    public sealed class SavedData<T> : BaseExample<T>
    {
        #region Fields

        public int CountBonuses;

        #endregion


        #region ClassLifeCycles

        public SavedData(T id) : base(id)
        {
            IdPlayer = id;
        }

        #endregion
    }
}
