namespace Todo.Business.Interface
{
    public interface IFileService
    {
        /// <summary>
        /// Returns virtual path fram createt pdf
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        string ChangeToPdf<T>(List<T> list) where T : class, new();
        /// <summary>
        /// Returns Exec as array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        byte[] ChangeToExcel<T>(List<T> list) where T : class, new();
    }
}
