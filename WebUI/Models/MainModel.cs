using Entities.Cocnrete;
using System.Collections.Generic;

namespace WebUI.Models
{
    public class MainModel
    {
        public NewsLetter NewsLetter { get; set; }
        public Contact Contact { get; set; }
        public Message Message { get; set; }
        public Comment Comment { get; set; }
        public GetSearchDestinationsModel GetSearchDestinationsModel { get; set; }
        public List<DestinationDetails> DestinationDetails { get; set; }
    }
}
