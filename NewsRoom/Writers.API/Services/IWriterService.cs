using Writers.API.Models;

namespace Writers.API.Services;

public interface IWriterService
{
    List<Writer> GetAll();
    Writer? Get(int id);
    Writer PostWriter(Writer writer);
}