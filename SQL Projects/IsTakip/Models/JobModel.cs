namespace IsTakip.Models
{
    public class JobModel
    {
        public int Id { get; set; }
        public string Person { get; set; }
        public string JobTitle { get; set; }    
        public string JobDetail { get; set; }
        public DateTime Date { get; set; }  
        public string? Active { get; set; }
        public string? Completed { get; set; }
        public string? Total { get; set; }
        public string Status { get; set; }
        public int StatusId { get; set; }   
    }
    
}
