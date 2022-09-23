using Writers.API.Models;

namespace Writers.API.Services;

public class WriterService : IWriterService
{
    private static readonly List<Writer> _writers = Populate();

    private static List<Writer> Populate()
    {
        var res = new List<Writer>()
        {
            new Writer()
            {
                Id = 1,
                Name = "John Doe"
            },
            new Writer()
            {
                Id = 2,
                Name = "Jane Doe"
            }
        };
        return res;
    }
    public List<Writer> GetAll()
    {
        return _writers;
    }

    public Writer? Get(int id)
    {
        return _writers.FirstOrDefault(w => w.Id == id);
    }

    public Writer PostWriter(Writer writer)
    {
        var maxId = _writers.Max(x => x.Id);
        writer.Id = +maxId;
        _writers.Add(writer);
        return writer;
    }
}