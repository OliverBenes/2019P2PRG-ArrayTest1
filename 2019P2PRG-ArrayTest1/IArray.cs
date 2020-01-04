namespace ArrayTest1
{
    public interface IArray
    {
        object Get(int position);
        object[] GetAll();
        void Add(object value);
        void Insert(object value, int position);
        bool Delete(object value);
        void Delete(int position);
        void ShiftItems(int indexFrom);
        int Count { get; }
        int Length { get; }
    }
}