
namespace Construxiv.Base.Models
{
    public class DBSettings: IDBSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IDBSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    } 
   
}
