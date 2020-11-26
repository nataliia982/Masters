using System;

namespace Socio.BusinessNew.Models
{
    public class SubscribtionViewModel
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
    }
}