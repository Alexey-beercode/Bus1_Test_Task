namespace TestTask.Models;

public class Link
{
    public int Id { get; set; }
    public string LongUrl { get; set; }
    public string ShortUrl { get; set; }
    public int Count { get; set; }
    public DateTime CreatedDate { get; set; }
}